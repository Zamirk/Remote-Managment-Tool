using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._2ViewModel.Test;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class AppScreen : Grid
    {
        int fontSize = 13;

        //SubScreen
        private OverviewAllScreen overviewScreen;
        
        public AppScreen()
        {
            Children.Add(new Label() { Text = "System Performance Screen" });

            //Initialising Overview Screen
            overviewScreen = new OverviewAllScreen();
            overviewScreen.Margin = new Thickness(50, 50, 50, 0);
            Children.Add(overviewScreen, 0, 0);

        }
    }
}