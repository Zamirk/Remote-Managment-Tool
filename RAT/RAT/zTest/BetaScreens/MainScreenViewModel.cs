using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using qwerty;
using RAT.ZTry;
using Tools;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace RAT._2ViewModel
{
	public class MainScreenViewModel : ViewModelBase
	{
		public MainScreenViewModel ()
		{

        }
         ICommand signOutCommand;

        //Command signs out
        public ICommand SignOutCommand =>
            signOutCommand ?? (signOutCommand = new Command(async () => await SignOut()));

	    private AzureService signingout;

        //Checks Login, Changes screen if found
        async Task SignOut()
        {
            signingout = DependencyService.Get<AzureService>();

            System.Diagnostics.Debug.WriteLine("\n-----Entering Main Menu");
            //Screen Navigation
            (Application.Current.MainPage).Navigation.InsertPageBefore(new LoginScreen(), (Application.Current.MainPage).Navigation.NavigationStack[0]);
            await (Application.Current.MainPage).Navigation.PopToRootAsync(false);

            signingout.Logout();

            GC.Collect();
        }
    }
}
