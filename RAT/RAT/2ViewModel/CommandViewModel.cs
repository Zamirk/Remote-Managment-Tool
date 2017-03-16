using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    class CommandViewModel
    {
        ICommand tapCommand;

        public CommandViewModel()
        {
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
        }
        public ICommand TapCommand
        {
            get
            {
                return tapCommand;
            }
        }

        void OnTapped(object s)
        {
            Debug.WriteLine("parameter: " + s);
        }
    }
}
