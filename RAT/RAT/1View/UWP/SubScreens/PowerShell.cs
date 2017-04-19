using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._2ViewModel;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class PowerShell : Grid
    {
        //private CommandViewModel viewModel;
        private Editor myEditor;

        public PowerShell()
        {
            myEditor = new Editor();
            myEditor.HorizontalOptions = LayoutOptions.StartAndExpand;
            myEditor.VerticalOptions = LayoutOptions.StartAndExpand;
            myEditor.BackgroundColor = Color.White;
            myEditor.Text = "Powershell screen";
        }

        public void GC()
        {
            //RemoveScreen();
        }
    }
}