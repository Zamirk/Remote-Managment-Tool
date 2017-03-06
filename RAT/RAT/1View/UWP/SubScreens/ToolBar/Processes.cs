using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._2ViewModel.Test;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class Processes : Grid
    {
        int fontSize = 13;
        
        public Processes()
        {
            Children.Add(new Label() { Text = "Processes" });
        }

        public void GC()
        {
            //RemoveScreen();
        }
    }
}