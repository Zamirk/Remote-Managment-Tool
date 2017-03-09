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
            symbol = "";
            account = "";
        }

        public void InitializeOn(Processes other)
        {
            this.Symbol = other.Symbol;
            this.Account = other.Account;
        }

        private string symbol;
        private string account;

        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                RaisePropertyChanged("Symbol");
            }
        }

        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                RaisePropertyChanged("Account");
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

