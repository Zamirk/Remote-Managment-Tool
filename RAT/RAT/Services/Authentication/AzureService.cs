using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;
using Xamarin.Forms;
using CoffeeCups.Helpers;
using CoffeeCups.Authentication;
using CoffeeCups;
using System.IO;
using DashboardModel;
using Newtonsoft.Json;
using RAT;
using RAT.ZTry;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using RAT._3Model;


namespace qwerty
{
    public class AzureService
    {
        public string replace { get; set; } =
            @"{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}";

        public string initialDashboard { get; set; } =
            "[[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬],[¬,¬,¬,¬,¬]]";

        public string placeHolder { get; set; } = "¬";

        //List of dashboards test
        public List<DashboardCellModel[][]> listOfDashboard { get; set; } = new List<DashboardCellModel[][]>()
        {
            new DashboardCellModel[8][]
        };

        public MobileServiceClient Client;
        public static bool UseAuth { get; set; } = true;
        private bool initialise = false;

        IMobileServiceTable<Login> loginTable;
        IMobileServiceTable<Dashboards> dashboardTable;

        private List<string> listOfIds;

        public async Task Initialize()
        {
            initialise = true;
            try
            {
                if (Client?.SyncContext?.IsInitialized ?? false)
                    return;

                Client = new MobileServiceClient("https://zmtool.azurewebsites.net", new AuthHandler());

                if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
                {
                    Client.CurrentUser = new MobileServiceUser(Settings.UserId);
                    Client.CurrentUser.MobileServiceAuthenticationToken = Settings.AuthToken;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Connection Error", "Please logout and try again", "OK");
            }
        }

        public async Task GetLogin()
        {
            //Initialize
            await Initialize();

            try
            {
                //Get our sync table that will call out to azure
                loginTable = Client.GetTable<Login>();

                List<Login> items = await loginTable
                    .Where(r => r.userId == Settings.UserId)
                    .ToListAsync();

                if (items.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("User found: ");

                    UserData.userId = items[0].userId;
                    UserData.connectionCode = items[0].ConnectionCode;
                    UserData.connectionString = items[0].ConnectionString;
                    UserData.eventHubEntity = items[0].EventHubEntity;
                    UserData.hostLink = items[0].HostLink;

                    System.Diagnostics.Debug.WriteLine("User found: " + items[0].userId);
                    System.Diagnostics.Debug.WriteLine("User found: " + items[0].ConnectionString);

                    //Getting dashboards
                    await GetDashboards();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Error", "Please contact support", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Connection Error", "Please logout and try again", "OK");
            }
        }

        public async Task GetDashboards()
        {
            listOfIds = new List<string>();
            dashboardTable = Client.GetTable<Dashboards>();
            System.Diagnostics.Debug.WriteLine("List of dashboards");

            List<Dashboards> listOfDashboards =
                await dashboardTable.Where(r => r.userId == UserData.userId).ToListAsync();

            //Looping trough dashboards
            for (int i = 0; i < listOfDashboards.Count; i++)
            {
                //Replacing token values
                listOfDashboards[i].DashString = listOfDashboards[i].DashString.Replace(placeHolder, replace);

                //Deserialising
                UserData.listOfDashboard[i] =
                    JsonConvert.DeserializeObject<DashboardCellModel[][]>(listOfDashboards[i].DashString);

                //Saving dashboard ids
                listOfIds.Add(listOfDashboards[i].Id);
            }
            UserData.listOfIds = listOfIds;
        }

        public async Task UpdateDashboard(Dashboards item)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Connecting to DashboardTable in Azure");
                dashboardTable = Client.GetTable<Dashboards>();
                await dashboardTable.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Connection Error", "Please logout and try again", "OK");
            }
        }

        /* Adding login to db
        public async Task AddLogin()
        {
            await Initialize();

            //Get our sync table that will call out to azure
            loginTable = Client.GetTable<Login>();

            var Login = new Login { userId = Settings.UserId };

            await loginTable.InsertAsync(Login);
        }
        */

        public void Logout()
        {
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;
        }

        public async Task<bool> LoginAsync()
        {
            await Initialize();

            try
            {
                var auth = DependencyService.Get<IAuthentication>();
                var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.MicrosoftAccount);

                if (user == null)
                {
                    Settings.AuthToken = string.Empty;
                    Settings.UserId = string.Empty;
                    Device.BeginInvokeOnMainThread(
                        async () =>
                        {
                            await App.Current.MainPage.DisplayAlert("Login Error", "Unable to login, please try again",
                                "OK");
                        });
                    return false;
                }
                else
                {
                    Settings.AuthToken = user.MobileServiceAuthenticationToken;
                    Settings.UserId = user.UserId;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Connection Error", "Please logout and try again", "OK");
            }
            return true;
        }
    }
}