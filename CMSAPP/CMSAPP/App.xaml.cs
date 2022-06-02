using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CMSAPP.Models;
using System.Collections.Generic;

namespace CMSAPP
{
    public partial class App : Application
    {
        public static readonly string baseUrl = "https://tjsegof.club/api/";
        public static readonly string userId = "1953474";

        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {

        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}



