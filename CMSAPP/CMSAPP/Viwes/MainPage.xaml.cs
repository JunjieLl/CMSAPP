using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Diagnostics;
using CMSAPP.Models;
using System.Text.Json;
using CMSAPP.Viwes;
using System.Net.Http;
using System.Text;


namespace CMSAPP.Viwes
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //roomWithFavorites = await getRooms();
            //roomWithFavorites = await getRooms();
            List<RoomWithFavorite> roomWithFavorites = new List<RoomWithFavorite>();//await getRooms();
            //BindingContext = roomWithFavorites;
            //roomWithFavorites.Add(new RoomWithFavorite { roomName = "jishilou1", state = "空闲", image = "https://tjsegof.club/images/room/0000000001.png" });
            //roomWithFavorites.Add(new RoomWithFavorite { roomName = "jishilou2", state = "空闲", image = "https://tjsegof.club/images/room/0000000002.png" });

            roomWithFavorites = await getRooms();//roomWithFavorites;

            List<RoomWithFavoriteForView> roomWithFavoriteForViews = new List<RoomWithFavoriteForView>();
            foreach (var room in roomWithFavorites)
            {
                roomWithFavoriteForViews.Add(new RoomWithFavoriteForView(room));
            }

            collectionView.ItemsSource = roomWithFavoriteForViews;
        }

        public async Task<List<RoomWithFavorite>> getRooms()
        {
            List<RoomWithFavorite> roomWithFavorites = new List<RoomWithFavorite>();
            try
            {
                Uri uri = new Uri(App.baseUrl + "Room/favorite/" + App.userId);

                var response = await App.httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    roomWithFavorites = JsonSerializer.Deserialize<List<RoomWithFavorite>>(content, App.serializerOptions);

                    Debug.WriteLine(roomWithFavorites);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return roomWithFavorites;
        }

        public async void clickImage(object sender, EventArgs e)
        {
            MyImageButton myImageButton = (MyImageButton)sender;
            string roomId = myImageButton.RoomId;
            //query parameter
            await Shell.Current.GoToAsync($"RoomDetail?roomId={roomId}");
        }

        //public async void favorite(object sender, EventArgs e)
        //{
            //MyImageButton myImageButton = (MyImageButton)sender;
            //string roomId = myImageButton.RoomId;
            //bool isFavo = myImageButton.IsFavo;
            //Uri uri;
            //if (isFavo)
            //{
            //    uri = new Uri($"{App.baseUrl}Favorite");
            //}
            //else
            //{
            //    uri = new Uri($"{App.baseUrl}Favorite/delete");
            //}

            //Favorite favorite = new Favorite(roomId, App.userId);
            //string json = JsonSerializer.Serialize<Favorite>(favorite, App.serializerOptions);
            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //try
            //{
            //    var response = await App.httpClient.PostAsync(uri, content);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        //refresh
            //       // OnAppearing();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
        //}

    }
}
