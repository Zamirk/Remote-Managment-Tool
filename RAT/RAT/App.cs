using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;

namespace RAT
{
	public class App : Application
	{
		public App ()
		{
            //MainPage = new NavigationPage(new IOTest());
            //MainPage = new NavigationPage(new DataGrid());
            MainPage = new NavigationPage(new LoginScreen());
            //MainPage = new NavigationPage(new MainPage());
        }
        public string DisplayLabelText { set; get; }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
