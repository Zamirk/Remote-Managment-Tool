using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class AppScreen : Grid
    {
        int fontSize = 13;

        public AppScreen()
        {
            Children.Add(new Label() { Text = "Notification Screen" });
        }
    }
}