using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;
using Xamarin.Forms;
using System.IO;
using DashboardModel;
using Newtonsoft.Json;
using RAT.ZTry;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using RAT._3Model;

namespace RAT.ZTry
{
    public class AzureLoginService
    {
        private const string replace = @"{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}";
        private const string placeHolder = "¬";
        private List<string> listOfIds;

        IMobileServiceTable<Login> loginTable;
        IMobileServiceTable<Dashboards> dashboardTable;

        MobileServiceClient client;

        public AzureLoginService()
        {
            client = new MobileServiceClient("http://zmtool.azurewebsites.net/");
        }

        //public async Task<ObservableCollection<Login>> GetLogin(string a, string b)

        public async Task<bool> GetLogin(string a, string b)
        {
            loginTable = client.GetTable<Login>();

            List<Login> items = await loginTable.
                Where(r => r.Username == a).
                Where(r => r.Password == b).
                ToListAsync();

            items.Add(new Login() { Password = "Empty", Username = "Empty" });

            if (items[0].Username.Equals(a) && items[0].Password.Equals(b))
            {
                System.Diagnostics.Debug.WriteLine("User found: " + items[0].Username);
                DashboardFromDatabase.userName = a;

                //Getting dashboards
                await GetDashboards(a);
                return true;
            }
            else
            {
                return false;
            }
            client.Dispose();
        }

        public async Task GetDashboards(string a)
        {
            listOfIds = new List<string>();
            dashboardTable = client.GetTable<Dashboards>();
            System.Diagnostics.Debug.WriteLine("List of dashboards");

            List<Dashboards> listOfDashboards = await dashboardTable.
                Where(r => r.Username == a).
                ToListAsync();

            //Looping trough dashboards
            for (int i = 0; i < listOfDashboards.Count; i++)
            {
                //Replacing token values
                listOfDashboards[i].DashString = listOfDashboards[i].DashString.Replace(placeHolder, replace);

                //Deserialising
                DashboardFromDatabase.listOfDashboard[i] = JsonConvert.DeserializeObject<DashboardCellModel[][]>(listOfDashboards[i].DashString);

                //Saving dashboard ids
                listOfIds.Add(listOfDashboards[i].Id);
            }
            DashboardFromDatabase.listOfIds = listOfIds;
        }

        public async Task UpdateDashboard(Dashboards item)
        {
            System.Diagnostics.Debug.WriteLine("Connecting to DashboardTable in Azure");
            dashboardTable = client.GetTable<Dashboards>();
            await dashboardTable.UpdateAsync(item);
        }
    }
    public class TodoItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}

