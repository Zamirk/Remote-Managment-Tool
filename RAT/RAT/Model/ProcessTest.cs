using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RAT.Model
{
    public class ProcessTest: INotifyPropertyChanged
    {
        public ProcessTest()
        {
            stockChange = "";
            open = "";
        }

        private string stockChange;
        private string open;
        private string time;
        private string cpu;

        public string Name
        {
            get { return stockChange; }
            set
            {
                stockChange = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Memory
        {
            get { return open; }
            set
            {
                open = value;
                RaisePropertyChanged("Memory");
            }
        }

        public string Cpu
        {
            get { return cpu; }
            set
            {
                cpu = value;
                RaisePropertyChanged("Cpu");
            }
        }

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                RaisePropertyChanged("Time");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

