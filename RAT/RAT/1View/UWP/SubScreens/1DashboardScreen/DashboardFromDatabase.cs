using System;
using System.Collections.Generic;
using System.Text;
using RAT._3Model;

namespace RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen
{
    class DashboardFromDatabase
    {
        public static string testString = @"[[{""G"":true,""T"":0,""R"":2,""C"":3,""D"":0, ""S"":0, ""N"":""CPU 1"", ""O"":0, ""X"":true, ""Y"":true, ""L"":true},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":true,""T"":11,""R"":1,""C"":3,""D"":0,""S"":5,""N"":""CPU 1"",""O"":2,""X"":true,""Y"":true,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}],[{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false},{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}]]";

        //List of dashboards
        public static List<DashboardCellModel[][]> listOfDashboard = new List<DashboardCellModel[][]>()
        {
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
            new DashboardCellModel[8][]
        {
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 0, O = 0,  N = "CPU 1", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 1, C = 3, R = 1, D = 0, S = 1, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 2, O = 2,  N = "Ram", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 2, C = 3, R = 1, D = 0, S = 3, O = 3,  N = "Ram used", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 1, D = 0, S = 4, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = true, T = 11, C = 3, R = 1, D = 0, S = 5, O = 2,  N = "CPU 1", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = true, T = 3, C = 3, R = 2, D = 0, S = 6, O = 1,  N = "CPU Frequency", X = true, Y = true, L = true},
                        new DashboardCellModel() { G = false, T = 2, C = 3, R = 1, D = 0, S = 7, O = 3,  N = "Ram", X = true, Y = false, L = false},
                        new DashboardCellModel() { G = true, T = 0, C = 3, R = 2, D = 0, S = 8, O = 2,  N = "Ram used", X = true, Y = true, L = false},
                        new DashboardCellModel() { G = false, T = 11, C = 3, R = 1, D = 0, S = 9, O = 1,  N = "Ram left", X = true, Y = true, L = false},
            },
                         new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },
                        new DashboardCellModel[5] {
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 2, O = 0,  N = "", D = 0, S = 0 },
                        new DashboardCellModel() { G = false, T = 0, O = 0,  N = "", D = 0, S = 0 },
            },

        },
        };



    }
}
