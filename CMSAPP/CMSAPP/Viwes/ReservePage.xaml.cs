using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Text.Json;
using CMSAPP.Models;
using System.ComponentModel;
using System.Text;
using System.Net.Http;

namespace CMSAPP.Viwes
{
    [QueryProperty(nameof(roomId), "roomId")]
    public partial class ReservePage : ContentPage
    {

        protected override void OnAppearing()
        {
            base.OnAppearing();

            getActivities();
        }

        public string RoomId;
        public string roomId
        {
            get
            {
                return RoomId;
            }
            set
            {
                RoomId = value;
                load();
            }
        }

        public async void load()
        {
            chargerEntry.Text = App.userName;

            dateChoose = DateTime.Now;
            datePicker.Date = dateChoose;

            Uri uri = new Uri($"{App.baseUrl}Room/AllGround");
            try
            {
                var response = await App.httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var grounds = JsonSerializer.Deserialize<List<Ground>>(content, App.serializerOptions);
                    grounds.Sort((ground1, ground2) => ground1.roomName.CompareTo(ground2.roomName));
                    int selectedIndex = -1,i=0;
                    grounds.ForEach(ground =>
                    {
                        roomNameId.Add(ground.roomName, ground.roomId);
                        spacePicker.Items.Add(ground.roomName);
                        if (ground.roomId.Equals(roomId))
                        {
                            selectedIndex = i;
                        }
                        ++i;
                    });
                    spacePicker.SelectedIndex = selectedIndex;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public ReservePage()
        {
            InitializeComponent();
        }
        //form
        private string activityName { get; set; }

        public void nameInput(object sender, EventArgs args)
        {
            activityName = ((Entry)sender).Text;
        }

        public Dictionary<string, string> roomNameId = new Dictionary<string, string>();
        //form 
        public string chooseRoomId { get; set; }

        

        public void sapcePickerChoose(object sender, EventArgs args)
        {
            Picker picker = sender as Picker;
            if (picker.SelectedIndex != -1)
            {
                chooseRoomId = picker.Items[picker.SelectedIndex];
                chooseRoomId = roomNameId[chooseRoomId];
                getActivities();
            }
        }

        //form
        public DateTime dateChoose { get; set; }
        //for form check
        public List<Activity> activities { get; set; }

        public void datePickerChoose(object sender, EventArgs args)
        {
            DatePicker datePicker = sender as DatePicker;
            dateChoose = datePicker.Date;//.ToString("yyyy-MM-dd");

            getActivities();
        }

        public async void getActivities()
        {
            if (chooseRoomId == null || dateChoose == null)
            {
                return;
            }

            //show occupyTime
            Uri uri2 = new Uri($"{App.baseUrl}Activity/room/{chooseRoomId}");
            try
            {
                var response2 = await App.httpClient.GetAsync(uri2);
                if (response2.IsSuccessStatusCode)
                {
                    var content2 = await response2.Content.ReadAsStringAsync();
                    activities = JsonSerializer.Deserialize<List<Activity>>(content2, App.serializerOptions);

                    List<StartToEnd> startToEnds = new List<StartToEnd>();

                    foreach (var activity in activities)
                    {
                        DateTime tempStart = DateTime.ParseExact(activity.start, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                        DateTime tempEnd = DateTime.ParseExact(activity.end, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);

                        if (tempStart.ToString("yyyy-MM-dd").Equals(dateChoose.ToString("yyyy-MM-dd")))
                        {
                            startToEnds.Add(new StartToEnd(tempStart.ToString("HH:mm") + "-" + tempEnd.ToString("HH:mm")));
                        }
                    }

                    startToEnds.Sort((s1, s2) => s1.startToEnd.CompareTo(s2.startToEnd));

                    RoomActivity.ItemsSource = startToEnds;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //form
        public TimeSpan startTimeSpan { get; set; }
        public void stratTimePickerChoose(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("Time"))
            {
                TimePicker timePicker = sender as TimePicker;
                startTimeSpan = timePicker.Time;
            }
        }
        //form
        public TimeSpan endTimeSpan { get; set; }
        public void endTimePickerChoose(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("Time"))
            {
                TimePicker timePicker = sender as TimePicker;
                endTimeSpan = timePicker.Time;
            }
        }
        //form
        public TimeSpan duration { get; set; }
        //desc
        public string desc { get; set; }
        public void descInput(object sender, EventArgs args)
        {
            Editor editor = sender as Editor;
            desc = editor.Text;
        }
        //form
        public int politicalRelevannt { get; set; } = 0;
        public void radioCheck(object sender, EventArgs args)
        {

            RadioButton radioButton = sender as RadioButton;
            if (!radioButton.IsChecked)
            {
                return;
            }
            if (radioButton.Content.Equals("是"))
            {
                politicalRelevannt = 1;
            }
            else
            {
                politicalRelevannt = 0;
            }
        }

        public async void submit(object sender, EventArgs args)
        {
            if (activityName == null || activityName.Equals(""))
            {
                await DisplayAlert("警告", "请填写活动名称", "确认");
                return;
            }

            if (chooseRoomId == null)
            {
                await DisplayAlert("警告", "请选择会议室", "确认");
                return;
            }

            if (dateChoose == null)
            {
                await DisplayAlert("警告", "请选择活动日期", "确认");
                return;
            }

            if (startTimeSpan == null)
            {
                await DisplayAlert("警告", "请选择开始时间", "确认");
                return;
            }


            if (endTimeSpan == null)
            {
                await DisplayAlert("警告", "请选择结束时间", "确认");
                return;
            }

            if (startTimeSpan >= endTimeSpan)
            {
                await DisplayAlert("警告", "开始时间比结束时间晚", "确认");
                return;
            }

            if (desc == null || desc.Equals(""))
            {
                await DisplayAlert("警告", "请填写活动描述", "确认");
                return;
            }

            //check conflict between reserve time
            foreach (var activity in activities)
            {
                DateTime startTime = DateTime.ParseExact(dateChoose.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture) + startTimeSpan;
                DateTime endTime = DateTime.ParseExact(dateChoose.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture) + endTimeSpan;

                DateTime activityStartTime = DateTime.ParseExact(activity.start, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);
                DateTime activityEndTime = DateTime.ParseExact(activity.end, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture);

                if (startTime > activityEndTime || activityStartTime > endTime)
                {
                    //ok
                }
                else
                {
                    await DisplayAlert("警告", "预约时间段与已有时间段冲突", "确认");
                    return;
                }
            }


            PostActivity postActivity = new PostActivity();
            postActivity.activityName = activityName;
            postActivity.activityDescription = desc;
            postActivity.roomId = chooseRoomId;
            postActivity.activityStatus = "待举办";
            postActivity.commonUserId = App.userId;
            postActivity.duration = (int)((endTimeSpan - startTimeSpan).TotalMinutes);
            postActivity.politicallyRelevant = politicalRelevannt;
            postActivity.startTime = (DateTime.ParseExact(dateChoose.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture) + startTimeSpan).ToString("yyyy-MM-dd HH:mm:ss");

            Uri uri = new Uri($"{App.baseUrl}Activity");
            try
            {
                string json = JsonSerializer.Serialize<PostActivity>(postActivity, App.serializerOptions);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await App.httpClient.PostAsync(uri, stringContent);

                //getActivities();

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("提示", "预约成功", "确认");
                    await Shell.Current.GoToAsync("..");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

    }
}

