using System;
using System.Collections.Generic;
using System.Text;

namespace RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen
{
    class DashboardFromDatabase
    {
        public static DashboardCellModel[][] myCells = new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = true, GraphType = 0, ColumnSpan = 3, RowSpan = 2, Device = 0, Datasource = 0, Colour = 0,  Title = "CPU 1", xAx = true, yAx = true, grid = true},
                        new DashboardCellModel() { hasGraph = false, GraphType = 1, ColumnSpan = 3, RowSpan = 1, Device = 0, Datasource = 1, Colour = 1,  Title = "CPU Frequency", xAx = true, yAx = true, grid = true},
                        new DashboardCellModel() { hasGraph = true, GraphType = 0, ColumnSpan = 3, RowSpan = 1, Device = 0, Datasource = 2, Colour = 2,  Title = "Ram", xAx = true, yAx = true, grid = false},
                        new DashboardCellModel() { hasGraph = true, GraphType = 2, ColumnSpan = 3, RowSpan = 1, Device = 0, Datasource = 3, Colour = 3,  Title = "Ram used", xAx = true, yAx = true, grid = true},
                        new DashboardCellModel() { hasGraph = true, GraphType = 0, ColumnSpan = 3, RowSpan = 1, Device = 0, Datasource = 4, Colour = 1,  Title = "Ram left", xAx = true, yAx = true, grid = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 2, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
                        new DashboardCellModel() { hasGraph = false, GraphType = 0, Colour = 0,  Title = "", Device = 0, Datasource = 0 },
            },

        };

        public void s()
        {
                    DashboardCellModel[][] myCells = new DashboardCellModel[8][];
        }
    }

    public class DashboardCellModel
    {
        //If yes, make graph
        public bool hasGraph { get; set; }

        public int GraphType { get; set; }

        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }

        public int Device { get; set; }
        public int Datasource { get; set; }

        //Theme
        public string Title { get; set; }
        public int Colour { get; set; }
        public bool xAx { get; set; }
        public bool yAx { get; set; }
        public bool grid { get; set; }
    }
}
