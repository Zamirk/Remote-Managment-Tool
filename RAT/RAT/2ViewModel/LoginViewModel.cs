using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeCups;
using CoffeeCups.Helpers;
using ConsoleApplication1.Folder;
using Tools;
using Xamarin.Forms;
using qwerty;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;

[assembly: Dependency(typeof(AzureService))]
namespace RAT.ZTry
{
    public class LoginViewModel: ViewModelBase
    {
        //AzureLoginService azureService;
        public AzureService azureService;

        //Login details
        private string userName = "";
        private string password = "";

        //Login validation command
        ICommand loginValidateCommand;

        public LoginViewModel()
        {
            //azureService = DependencyService.Get<AzureLoginService>();
            //azureService = new AzureLoginService();
            azureService = DependencyService.Get<AzureService>();

            //Logining first
            GetUserCredentials();
        }

         async Task GetUserCredentials()
         {
             if (!(await LoginAsync()))
                 return;
             try
             {
                 await azureService.GetLogin();
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine("GetUserCredentials OH NO!" + ex);
             }
         }
         
        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return azureService.LoginAsync();
        }

        public string UserName
        {
            set { SetProperty(ref userName, value); }
            get { return userName; }
        }

        public string Password
        {
            set { SetProperty(ref password, value); }
            get { return password; }
        }

        //Command sends Username and Password to method
        public ICommand LoginValidateCommand =>
            loginValidateCommand ?? (loginValidateCommand = new Command(async () => await LoginValidate()));

        //Checks Login, Changes screen if found
        async Task LoginValidate()
        {
                if (UserData.userId != "")
                {
                    (Application.Current.MainPage).Navigation.InsertPageBefore(new ParentScreen(),
                        (Application.Current.MainPage).Navigation.NavigationStack[0]);
                    GC.Collect();

                    //Starts 2 async tasks to get telemetry data
                    Task t = Task.Factory.StartNew(() => {
                        GetTelemetry.ReceiveTelemetry();
                    });
                    Task tt = Task.Factory.StartNew(() => {
                        GetTelemetry.ReceiveTelemetry2();
                    });

                    await (Application.Current.MainPage).Navigation.PopToRootAsync(false);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Please login with a valid account",
                        "Error: Invalid account, or connection problem", "OK");
                    Settings.AuthToken = string.Empty;
                    Settings.UserId = string.Empty;
                }

        }
    }
}


