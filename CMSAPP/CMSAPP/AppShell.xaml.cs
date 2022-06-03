using System;
using System.Collections.Generic;
using CMSAPP.Viwes;

using Xamarin.Forms;

namespace CMSAPP
{	
	public partial class AppShell : Shell
	{	
		public AppShell ()
		{
			InitializeComponent();
			Routing.RegisterRoute("RoomDetail", typeof(RoomDetail));
		}
	}
}