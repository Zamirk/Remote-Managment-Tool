using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsoleApplication1.Folder;
using Tools;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class LoginViewModel: ViewModelBase
    {
        AzureLoginService azureService;

        //Login details
        private string userName = "";
        private string password = "";

        //Login validation command
        ICommand loginValidateCommand;

        public LoginViewModel()
        {
            //azureService = DependencyService.Get<AzureLoginService>();
            azureService = new AzureLoginService();
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

            if (await azureService.GetLogin(userName, password))
            {
                System.Diagnostics.Debug.WriteLine("\n-----Entering Main Menu");
                //Screen Navigation
                if (Device.OS == TargetPlatform.Android)
                {
                    //(Application.Current.MainPage).Navigation.InsertPageBefore(new Mobile.ParentScreen(),
                    //    (Application.Current.MainPage).Navigation.NavigationStack[0]);
                   // await (Application.Current.MainPage).Navigation.PopToRootAsync(false);
                   // GC.Collect();
                }
                else
                {
                    (Application.Current.MainPage).Navigation.InsertPageBefore(new ParentScreen(),
                        (Application.Current.MainPage).Navigation.NavigationStack[0]);
                    GC.Collect();
                }

                //Gets the data IoT
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
                        System.Diagnostics.Debug.WriteLine("Incorrect Login");
            }
        }
    }
}


