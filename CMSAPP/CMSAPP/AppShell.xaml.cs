using System;
using System.Collections.Generic;
using CMSAPP.Viwes;

using Xamarin.Forms;

namespace CMSAPP
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("RoomDetail", typeof(RoomDetail));
			Routing.RegisterRoute("Reserve", typeof(ReservePage));
			Routing.RegisterRoute("Modify", typeof(ActivityModifyPage));
			Routing.RegisterRoute("ViewActivityInfo", typeof(ActivityViewPage));
			Routing.RegisterRoute("ViewActivityInfoWithFeedback", typeof(ActivityViewWithFeedbackPage));
			Routing.RegisterRoute("login", typeof(LoginPage));
			Routing.RegisterRoute("main", typeof(MainPage));
			Routing.RegisterRoute("activity", typeof(MyActivityPage));
		}
	}
}