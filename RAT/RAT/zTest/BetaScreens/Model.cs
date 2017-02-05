#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
    public class Model
    {
        public string Name { get; set; }

        public DateTime date { get; set; }

        public double Value { get; set; }

 		public double Value1 { get; set; }

        public double Size { get; set; }

        public double High { get; set; }

        public double Low { get; set; }
          
        public Model(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public Model(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
	
		public Model(double value, double value1, double size)
        {
            Value1 = value;
            Value = value1;
            Size = size;
        }

        public Model(string name, double high, double low, double open, double close)
        {
            Name = name;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
		public Model(DateTime Date, double high, double low, double open, double close)
        {
            date = Date;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
        public Model(double value, double size)
        {
            Value = value;
            Size = size;
        }

        public Model(DateTime dateTime, double value)
        {
            date = dateTime;
            Value = value;
        }
    }
}