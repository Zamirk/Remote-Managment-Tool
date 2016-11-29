#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class ViewModel
    {
        DateTime time = new DateTime(2015, 01, 01);

        Random random = new Random();

        private int count;

        private int wave1 = 0;

        private int wave2 = 180;


        public ObservableCollection<Model> data { get; set; }

        public ObservableCollection<Model> liveData1 { get; set; }

        public ObservableCollection<Model> liveData2 { get; set; }

        public ViewModel()
        {
            data = new ObservableCollection<Model>();

            liveData1 = new ObservableCollection<Model>();

            liveData2 = new ObservableCollection<Model>();
        }

        public void LoadData()
        {
            for (var i = 0; i < 2; i++)
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
            }
            count = data.Count;

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
                return true;
            });
        }

        public async void LoadData1()
        {
            for (var i = 0; i < 180; i++)
            {
                liveData1.Add(new Model(i, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;
            }

            for (var i = 0; i < 180; i++)
            {
                liveData2.Add(new Model(i, Math.Sin(wave2*(Math.PI/180.0))));
                wave2++;
            }

            wave1 = liveData1.Count;

            await Task.Delay(200);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), () =>
            {
                //liveData1.RemoveAt(0);
                liveData1.Add(new Model(wave1, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;

                //liveData2.RemoveAt(0);
                liveData2.Add(new Model(wave1, Math.Sin(wave2*(Math.PI/180.0))));
                wave2++;
                return true;
            });
        }
    }
}