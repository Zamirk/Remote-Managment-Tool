using System;
using System.ComponentModel;

namespace SampleBrowser
{
	public class DeviceInfo : INotifyPropertyChanged
	{
	    public DeviceInfo()
	    {
        symbol = "";
        account = "";
        lastTrade = 0;
        stockChange = 0;
        previousClose = 0;
        open = 0;
        volume = 0;
        }

        public void InitializeOn(DeviceInfo other)
        {
            this.Symbol = other.Symbol;
            this.LastTrade = other.LastTrade;
            this.StockChange = other.StockChange;
            this.PreviousClose = other.PreviousClose;
            this.Open = other.Open;
            this.Volume = other.Volume;
        }

        private string symbol;
		private string account;
		private double lastTrade;
		private double stockChange;
		private double previousClose;
		private double open;
		private long volume;

		public double StockChange {
			get { return stockChange; }
			set {
				stockChange = value;
				RaisePropertyChanged ("StockChange");
			}
		}

		public double Open {
			get { return open; }
			set {
				open = value;
				RaisePropertyChanged ("Open");
			}
		}

		public double LastTrade {
			get { return lastTrade; }
			set {
				lastTrade = value;
				RaisePropertyChanged ("LastTrade");
			}
		}

		public double PreviousClose {
			get { return previousClose; }
			set {
				previousClose = value;
				RaisePropertyChanged ("PreviousClose");
			}
		}

		public string Symbol {
			get { return symbol; }
			set {
				symbol = value;
				RaisePropertyChanged ("Symbol");
			}
		}

		public string Account {
			get { return account; }
			set {
				account = value;
				RaisePropertyChanged ("Account");
			}
		}

		public long Volume {
			get { return volume; }
			set {
				volume = value;
				RaisePropertyChanged ("Volume");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

