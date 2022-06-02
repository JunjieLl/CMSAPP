using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;
using CMSAPP.Models;
using System.Text.Json;


namespace CMSAPP
{
    public partial class MainPage : ContentPage
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly JsonSerializerOptions serializerOptions= new JsonSerializerOptions{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

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

            collectionView.ItemsSource = await getRooms();//roomWithFavorites;


        }

        public async Task<List<RoomWithFavorite>> getRooms()
        {
            List<RoomWithFavorite> roomWithFavorites = new List<RoomWithFavorite>();
            try
            {
                Uri uri = new Uri(App.baseUrl + "Room/favorite/" + App.userId);

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    roomWithFavorites = JsonSerializer.Deserialize<List<RoomWithFavorite>>(content, serializerOptions);

                    Debug.WriteLine(roomWithFavorites);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return roomWithFavorites;
        }
    }
}



