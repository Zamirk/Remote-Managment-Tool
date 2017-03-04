using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RAT.ZTry;
using Mobile;

namespace RAT
{
	public class App : Application
	{
		public App ()
		{
            //MainPage = new NavigationPage(new IOTest());
            //MainPage = new NavigationPage(new DataGrid());c
            if (Device.OS == TargetPlatform.Windows)
            {
                MainPage = new NavigationPage(new ZTry.LoginScreen());
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                MainPage = new NavigationPage(new Mobile.LoginScreen());
            }
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
