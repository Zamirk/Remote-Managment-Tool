using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._2ViewModel.Test;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class Temp : Grid
    {
        int fontSize = 13;
        
        public Temp()
        {
            Children.Add(new Label() { Text = "Temp" });
        }

        public void GC()
        {
            //RemoveScreen();
        }
    }
}