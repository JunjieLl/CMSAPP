﻿using System;
using System.Collections.Generic;
using CMSAPP.Models;
using Xamarin.Forms;
using System.Text.Json;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace CMSAPP.Viwes
{
    [QueryProperty(nameof(roomId), "roomId")]
    public partial class RoomDetail : ContentPage
    {
        public RoomDetail()
        {
            InitializeComponent();
        }

        public string RoomId;

        public string roomId
        {
            set
            {
                DatePicker.Date = DateTime.Now;
                RoomId = value;
                loadRoom();

            }
            get
            {
                return RoomId;
            }
        }

        protected override async void OnAppearing()
        {
            selectDate(null, null);
        }

        //init
        public async void loadRoom()
        {
            //get info of room
            Uri uri = new Uri($"{App.baseUrl}Room/favorite/{App.userId}/{RoomId}");
            try
            {
                var response = await App.httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var roomWithFavorite = JsonSerializer.Deserialize<RoomWithFavorite>(content, App.serializerOptions);
                    RoomWithFavoriteForView roomWithFavoriteForView = new RoomWithFavoriteForView(roomWithFavorite);
                    RoomDetailView.BindingContext = roomWithFavoriteForView;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            selectDate(null, null);
        }

        public async void selectDate(object sender, EventArgs e)
        {
            //get activity of corresponding room
            Uri uri2 = new Uri($"{App.baseUrl}Activity/room/{RoomId}");
            try
            {
                var response2 = await App.httpClient.GetAsync(uri2);
                if (response2.IsSuccessStatusCode)
                {
                    var content2 = await response2.Content.ReadAsStringAsync();
                    var activities = JsonSerializer.Deserialize<List<Activity>>(content2, App.serializerOptions);
                    activities.Sort((s1, s2) =>
                    {
                        return DateTime.ParseExact(s1.start, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture).CompareTo(
                         DateTime.ParseExact(s2.start, "yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.CurrentCulture));
                    });

                    activities.ForEach(activity =>
                    {
                        activity.start = "开始： " + activity.start;
                        activity.start = activity.start.Replace("T", " ");
                        activity.end = "结束： " + activity.end;
                        activity.end = activity.end.Replace("T", " ");
                        activity.title = "会议：" + activity.title;
                    });

                    string chooseDate = DatePicker.Date.ToString("yyyy-MM-dd");
                    var showActivities = activities.FindAll(activity => activity.start.Contains(chooseDate));
                    
                    RoomActivity.ItemsSource = showActivities;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public async void favorite(object sender, EventArgs e)
        {
            MyImageButton myImageButton = (MyImageButton)sender;
            string roomId = myImageButton.RoomId;
            bool isFavo = myImageButton.IsFavo;
            Uri uri;
            if (isFavo)
            {
                uri = new Uri($"{App.baseUrl}Favorite/delete");
            }
            else
            {
                uri = new Uri($"{App.baseUrl}Favorite");
            }

            Favorite favorite = new Favorite(roomId, App.userId);
            string json = JsonSerializer.Serialize<Favorite>(favorite, App.serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await App.httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    //refresh
                    loadRoom();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        public async void reserve(object sender, EventArgs args)
        {
            Button button = sender as Button;

            await Shell.Current.GoToAsync($"Reserve?roomId={RoomId}");
        }
    }
}

