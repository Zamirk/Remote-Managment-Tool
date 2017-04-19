using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RAT.Model
{
    public class Processes: INotifyPropertyChanged
    {
        public Processes()
        {
            name = "";
            memory = "";
            time = "";
            cpu = "";
        }

        private string name;
        private string memory;
        private string time;
        private string cpu;
        #region private variables

        private string _employeeID;
        private string _customerID;
        private string _userName;

        #endregion

        public string UserName
        {
            get { return _userName; }
            set
            {
                this._userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string EmployeeID
        {
            get { return _employeeID; }
            set
            {
                this._employeeID = value;
                RaisePropertyChanged("EmployeeID");
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

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
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

