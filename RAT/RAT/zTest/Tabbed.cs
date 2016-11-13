using RAT.ZTry;
using Xamarin.Forms;

namespace RAT.zTest
{
	public class Tabbed : TabbedPage
	{
        public Tabbed()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var navigationPage = new NavigationPage(new LoginScreen());
            //navigationPage.Icon = "schedule.png";
            //navigationPage.Title = "Schedule";

            Children.Add(new LoginScreen());
            Children.Add(navigationPage);
            Children.Add(new LoginScreen());

            this.Children[0].Title = "Page 1";
            this.Children[1].Title = "Page 2";
            this.Children[2].Title = "Page 3";
        }
    }
}
