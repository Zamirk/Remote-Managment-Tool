using Xamarin.Forms;

namespace RAT._1View
{
	public class MainPageCS : ContentPage
	{
		public MainPageCS ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello Page" }
				}
			};
		}
	}
}
