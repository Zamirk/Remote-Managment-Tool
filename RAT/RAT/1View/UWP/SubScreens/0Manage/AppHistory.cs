﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class AppHistory : Grid
    {
        int fontSize = 13;

        public AppHistory()
        {
            Children.Add(new Label() { Text = "App history" });
        }
        public void GC()
        {
            //RemoveScreen();
        }
    }
}