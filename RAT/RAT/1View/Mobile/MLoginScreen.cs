using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RAT._1View.Mobile
{
	public class MLoginScreen : ContentPage
	{
		public MLoginScreen ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello Page" }
				}
			};
		}
	}
}
