using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1;
using DashboardModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using qwerty;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using RAT._1View.UWP.SubScreens._1DashboardScreen;
using RAT._3Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void JSonConvertTest()
        {
            string dashboardString = "";
            AzureService myAzureService = new AzureService();
            dashboardString = myAzureService.initialDashboard;
            dashboardString = dashboardString.Replace(myAzureService.placeHolder, myAzureService.replace);
            myAzureService.listOfDashboard[0] = JsonConvert.DeserializeObject<DashboardCellModel[][]>(dashboardString);
            string finalDashboard = JsonConvert.SerializeObject(myAzureService.listOfDashboard[0]);
            finalDashboard = finalDashboard.Replace(myAzureService.replace, myAzureService.placeHolder);
            Assert.AreEqual(myAzureService.initialDashboard, finalDashboard);
        }

        [TestMethod]
        public void DashboardCellIComparableTest()
        {
            const int first = 0;
            const int second = 1;

            List<CellPos> myList = new List<CellPos>();
            myList.Add(new CellPos(){Pos = second });
            myList.Add(new CellPos() { Pos = first });

            myList = myList.OrderBy(o => o.Pos).ToList();
            Assert.AreEqual(myList[0].Pos, first);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandArguments()
        {
                CommandDatapoint aa = new CommandDatapoint(new DateTime(), "", "", CommandType.CloseProcess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DashboardModelTest()
        {
            Dashboards aa = new Dashboards("12345");
        }

        [TestMethod]
        public void JSonTest2()
        {
            string final = @"{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}";

            DashboardCellModel myCell = new DashboardCellModel();
            string JSonCell = JsonConvert.SerializeObject(myCell);
            Assert.AreEqual(final, JSonCell);
        }
    }
}
