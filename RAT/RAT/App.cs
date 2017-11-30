using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RAT.ZTry;

namespace RAT
{
	public class App : Application
	{
		public App ()
		{
            if (Device.OS == TargetPlatform.Windows)
            {
                MainPage = new NavigationPage(new ZTry.LoginScreen());
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                MainPage = new NavigationPage(new ZTry.LoginScreen());
                // Seperate GUI removed for now
                // MainPage = new NavigationPage(new Mobile.LoginScreen());
            }
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
