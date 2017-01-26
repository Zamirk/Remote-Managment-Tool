using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Agent._3Model;
using EasyWpfLoginNavigateExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EasyWpfLoginNavigateExample.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using RAT.ZTry;


namespace Agent._2ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        AzureLoginService azureService;
        public LoginViewModel()
        {
            azureService = new AzureLoginService();
            LoginCommand = new RelayCommand(DoLogin);
        }

        #region Members
        //Login validation command
        public RelayCommand LoginCommand { get; set; }

        //Login details
        private string userName = "";
        private string password = "";

        #endregion

        #region Properties

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }

        #endregion

        private void DoLogin(object obj)
        {
            //Getting Password
            var passwordBox = obj as PasswordBox;
            var password = passwordBox.Password;
            this.password = password.ToString();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync(10000);

        }
        //Getting Password


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;

            Console.WriteLine("Test method begins.");
            //((MainWindow) System.Windows.Application.Current.MainWindow).label.Target.Visibility = Visibility.Hidden;
            LoginValidate();
        }

        //Checks Login, Changes screen if found
        async void LoginValidate(){

        List <Login> logins = await azureService.GetLogin("Admin", "1234");
            if (logins[0].Username.Equals(UserName) && logins[0].Password.Equals(password))
            {
                System.Diagnostics.Debug.WriteLine("\n-----Database."+UserName + "Pass" + password);
                //Screen Navigation
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Incorrect Login");
            }
        }
    }
}
