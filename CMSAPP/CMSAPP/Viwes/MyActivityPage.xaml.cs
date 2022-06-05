using System;
using System.Collections.Generic;
using CMSAPP.Models;
using Xamarin.Forms;
using System.Text.Json;
using System.Net.Http;
using System.Diagnostics;


namespace CMSAPP.Viwes
{	
	public partial class MyActivityPage : ContentPage
	{	
		public MyActivityPage ()
		{
			InitializeComponent ();
		}


		private List<string> showTypes { get; set; } = new List<string> { "待举办", "待反馈", "已反馈", "被驳回", "已取消" };

		public async void pickerSelect(object sender,EventArgs args)
        {
			Picker picker = sender as Picker;

			Uri uri = new Uri($"{App.baseUrl}Activity?commonUserId={App.userId}");
			try
			{
				var response = await App.httpClient.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					Dictionary<string, List<MyActivityPageModel>> activities =
						JsonSerializer.Deserialize<Dictionary<string, List<MyActivityPageModel>>>(content, App.serializerOptions);


					List<MyActivityPageModelForView> myActivityPageModelForViews = new List<MyActivityPageModelForView>();
                    if (activities.ContainsKey(showTypes[picker.SelectedIndex])){
						foreach (var a in activities[showTypes[picker.SelectedIndex]])
						{
							myActivityPageModelForViews.Add(new MyActivityPageModelForView(a));
						}

						
					}
					collectionView.ItemsSource = myActivityPageModelForViews;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

		}

		protected override void OnAppearing()
        {
			picker.Items.Clear();
			foreach(var s in showTypes)
            {
				picker.Items.Add(s);
            }
			picker.SelectedIndex = 0;
		}

		public async void modifyRecord(System.Object sender, System.EventArgs e)
        {
			MyButton myButton = sender as MyButton;
			string url = $"Modify?PassactivityId={myButton.PassactivityId}&PassactivityName={myButton.PassactivityName}&" +
				$"PassstartTime={myButton.PassstartTime}&Passduration={myButton.Passduration}&" +
				$"PassactivityDescription={myButton.PassactivityDescription}&PassuserName={myButton.PassuserName}&" +
				$"&PasspoliticallyRelevant={myButton.PasspoliticallyRelevant}&" +
				$"Passreason={myButton.Passreason}&PassroomId={myButton.PassroomId}&" +
                $"PasspoliticalReview={myButton.PasspoliticalReview}";

			//await Shell.Current.GoToAsync($"Modify?PassactivityId={myButton.PassactivityId}&?PassactivityName={myButton.PassactivityName}&" +
   //             $"PassstartTime={myButton.PassstartTime}&Passduration={myButton.Passduration}&" +
   //             $"PassactivityDescription={myButton.PassactivityDescription}&PassuserName={myButton.PassuserName}&" +
   //             $"PasspoliticalReview={myButton.PasspoliticalReview}&PasspoliticallyRelevant={myButton.PasspoliticallyRelevant}&" +
   //             $"Passreason={myButton.Passreason}&PassroomId={myButton.PassroomId}");
            await Shell.Current.GoToAsync(url);
		}

	}
}

