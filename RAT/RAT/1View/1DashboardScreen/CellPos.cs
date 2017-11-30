using System;
using System.Collections.Generic;
using System.Text;

namespace RAT._1View.UWP.SubScreens._1DashboardScreen
{
    public class CellPos : IComparable<CellPos>
    {
        public int Pos { get; set; }

        //Compare method
        public int CompareTo(CellPos o)
        {
            return this.Pos.CompareTo(o.Pos);
        }
    }
}
