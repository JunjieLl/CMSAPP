using System;
using System.Collections.Generic;
using CMSAPP.Models;
using Xamarin.Forms;
using System.Text.Json;
using System.Diagnostics;

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

                RoomId = value;
                loadRoom();

            }
            get
            {
                return RoomId;
            }
        }

        public RoomWithFavorite roomWithFavorite { get; set; }

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
                    roomWithFavorite = JsonSerializer.Deserialize<RoomWithFavorite>(content, App.serializerOptions);
                    RoomWithFavoriteForView roomWithFavoriteForView = new RoomWithFavoriteForView(roomWithFavorite);
                    RoomDetailView.BindingContext = roomWithFavoriteForView;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            //get activity of corresponding room
            Uri uri2 = new Uri($"{App.baseUrl}Activity/room/{RoomId}");
            try
            {
                var response2 = await App.httpClient.GetAsync(uri2);
                if (response2.IsSuccessStatusCode)
                {
                    var content2 = await response2.Content.ReadAsStringAsync();
                    List<Activity> activitys = JsonSerializer.Deserialize<List<Activity>>(content2, App.serializerOptions);
                    activitys.ForEach(activity =>
                    {
                        activity.start = "开始： " + activity.start;
                        activity.end = "结束： " + activity.end;
                        activity.title = "会议：" + activity.title;
                    });

                    RoomActivity.ItemsSource = activitys;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //protected override async void OnAppearing()
        //      {
        //	base.OnAppearing();
        //	Uri uri = new Uri(App.baseUrl + $"Room/favorite/{App.userId}/{roomId}");
        //	var response = App.httpClient.GetAsync
        //      }
    }
}

