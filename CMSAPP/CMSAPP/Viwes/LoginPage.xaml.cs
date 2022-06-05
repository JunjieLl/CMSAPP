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
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

        public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
			string id = idLabel.Text;
			string pass = passLabel.Text;
            if (id == null || id.Equals("") || pass == null || pass.Equals(""))
            {
				await DisplayAlert("警告", "请填写密码", "确认");
				return;
            }

			PostLogin postLogin = new PostLogin();
			postLogin.userId = id;
			postLogin.password = pass;

			string json = JsonSerializer.Serialize<PostLogin>(postLogin, App.serializerOptions);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			Uri uri = new Uri($"{App.baseUrl}login");
            try
            {
				var response = await App.httpClient.PostAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
					var content = await response.Content.ReadAsStringAsync();
					User user = JsonSerializer.Deserialize<User>(content, App.serializerOptions);
					App.userId = user.userId;
					App.userName = user.userName;
					await DisplayAlert("提示", "登录成功", "确认");
					await Shell.Current.GoToAsync("../..");
				}
                else
                {
					await DisplayAlert("警告", "学号或密码错误，请重试", "确认");
				}
            }
			catch(Exception ex)
            {
				Debug.WriteLine(ex);
            }
		}
    }
}

