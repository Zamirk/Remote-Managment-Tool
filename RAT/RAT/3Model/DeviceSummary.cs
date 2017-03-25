using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RAT.Model
{
    public class DeviceSummary : INotifyPropertyChanged
    {
        public DeviceSummary()
        {
            name = "";
            cpu = "";
            memory = "";
            disk = "";
            wifi = "";
        }

        private string name;
        private string cpu;
        private string memory;
        private string disk;
        private string wifi;

        #region private variables

        private string _employeeID;
        private string _customerID;
        private string _userName;

        #endregion

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
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

        public string Memory
        {
            get { return memory; }
            set
            {
                memory = value;
                RaisePropertyChanged("Memory");
            }
        }

        public string Disk
        {
            get { return disk; }
            set
            {
                disk = value;
                RaisePropertyChanged("Disk");
            }
        }

        public string Wifi
        {
            get { return wifi; }
            set
            {
                wifi = value;
                RaisePropertyChanged("Wifi");
            }
        }

        public string CustomerID
        {
            get { return _customerID; }
            set
            {
                this._customerID = value;
                RaisePropertyChanged("CustomerID");
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

