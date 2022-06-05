using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CMSAPP.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;


namespace CMSAPP
{
    public partial class App : Application
    {
        //some user info
        public static readonly string baseUrl = "https://tjsegof.club/api/";
        public static string userId;
        public static string userName;

        //httpclient
        public static readonly HttpClient httpClient = new HttpClient();
        public static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}