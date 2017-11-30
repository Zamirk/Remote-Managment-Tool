using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Media.Audiofx;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoffeeCups.Helpers;
using RAT._2ViewModel;
using Xamarin.Forms;

namespace PlatInfoSap2
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Settings.UserId = String.Empty;
            Settings.AuthToken = String.Empty;

            var activity = (Activity) Forms.Context;
            activity.FinishAffinity();
        }
    }
}