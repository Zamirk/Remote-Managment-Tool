using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SampleBrowser;

namespace RAT._1View.Desktop.Screens.SubScreens
{
    class ViewDevicesViewModel
    {
        public ObservableCollection<TestModel> data = new ObservableCollection<TestModel>();
        private Random r = new Random();
        public ViewDevicesViewModel()
        {
            data.Add(new TestModel());
            data.Add(new TestModel());
            data.Add(new TestModel());
        }
    }
}
