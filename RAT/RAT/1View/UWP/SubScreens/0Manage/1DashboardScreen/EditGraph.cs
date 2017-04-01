using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RAT._1View.Desktop.Manage;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    public partial class EditGraph : PopupPage
    {
        private StackLayout mainLayout, titleLayout;
        private StackLayout[] layouts;
        private Switch[] switches;
        private Picker colourSelect;
        private Label[] labels;
        public Button saveButton = new Button();
        public Editor titleEditor;
        private Label myLabel, switchLabel1, switchLabel2;

        public bool XAxisValue { get; set; }
        public bool YXaxisValue { get; set; }
        public bool GridLinesValues { get; set; }
        public int ColourPicked { get; set; }
        public string TitleTyped { get; set; }

        public EditGraph()
        {
        //Initialising
        layouts = new StackLayout[10];
            switches = new Switch[10];
            labels = new Label[10];
            titleEditor = new Editor();

            colourSelect = new Picker();
            colourSelect.Items.Add("Orange theme");
            colourSelect.Items.Add("Blue theme");
            colourSelect.Items.Add("Green theme");

            //Layout
            mainLayout = new StackLayout();
            mainLayout.Orientation = StackOrientation.Vertical;
            mainLayout.HorizontalOptions = LayoutOptions.Center;
            mainLayout.VerticalOptions = LayoutOptions.Center;
            mainLayout.BackgroundColor = Color.Black;
            mainLayout.WidthRequest = 300;
            mainLayout.HeightRequest = 200;

            #region MyRegion
            StackLayout aaa = new StackLayout();
            aaa.BackgroundColor = Color.Gray;
            titleEditor.WidthRequest = 200;
            titleEditor.VerticalOptions = LayoutOptions.CenterAndExpand;
            aaa.Children.Add(titleEditor);

            mainLayout.Children.Add(aaa);
            #endregion

            #region MyRegion

            StackLayout bbb = new StackLayout();
            bbb.Orientation = StackOrientation.Horizontal;
            bbb.BackgroundColor = Color.Gray;

            Label colour = new Label();
            colour.FontSize = 20;
            //colour.TextColor = Color.Lime;
            colour.HorizontalOptions = LayoutOptions.Start;
            colour.VerticalOptions = LayoutOptions.Start;
            colour.Text = "Colour";

            colourSelect.SelectedIndex = 0;
            colourSelect.WidthRequest = 200;
            colourSelect.HeightRequest = 35;
            colourSelect.HorizontalOptions = LayoutOptions.End;

            bbb.Children.Add(colour);
            bbb.Children.Add(colourSelect);
            mainLayout.Children.Add(bbb);

            #endregion

            #region MyRegion
            
            String[] text = new String[10]{ "XAxis", "YAxis","GridLines","","","","","","",""};

            //Generating components
            for (int i = 0; i < 3; i++)
            {
                layouts[i] = new StackLayout();
                layouts[i].Orientation = StackOrientation.Horizontal;
                layouts[i].BackgroundColor = Color.Gray;

                labels[i] = new Label();
                labels[i].FontSize = 20;
                labels[i].TextColor = Color.Lime;
                labels[i].HorizontalOptions = LayoutOptions.CenterAndExpand;
                labels[i].VerticalOptions = LayoutOptions.CenterAndExpand;
                labels[i].Text = text[i];

                switches[i] = new Switch();
                switches[i].HorizontalOptions = LayoutOptions.CenterAndExpand;
                layouts[i].Children.Add(labels[i]);
                layouts[i].Children.Add(switches[i]);
                mainLayout.Children.Add(layouts[i]);
            }

            //Adding event handlers
            switches[0].Toggled += OnToggledXAxis;
            switches[1].Toggled += OnToggledYAxis;
            switches[2].Toggled += OnToggledGridLines;

            //Dropdown selection event
            colourSelect.SelectedIndexChanged += ColourSelectOnSelectedIndexChanged;
            
            //Editor changed event
            titleEditor.TextChanged += TitleEditorOnTextChanged;
            
            #endregion

            #region MyRegion

            StackLayout buttonLayout = new StackLayout();
            buttonLayout.Orientation = StackOrientation.Horizontal;
            buttonLayout.BackgroundColor = Color.Gray;

            saveButton.Text = "Save";
            saveButton.VerticalOptions = LayoutOptions.Center;
            saveButton.HorizontalOptions = LayoutOptions.Center;
            saveButton.Margin = new Thickness(75,0,0,0);
            saveButton.FontSize = 20;
            buttonLayout.Children.Add(saveButton);

            mainLayout.Children.Add(buttonLayout);

                #endregion

            this.Content = mainLayout;
        }

        public void SetAttributes(bool a, bool b, bool c, string d, int e)
        {
            //Setting values that were sent in
            XAxisValue = a;
            YXaxisValue = b;
            GridLinesValues = c;
            TitleTyped = d;
            colourSelect.SelectedIndex = e;

            //Setting initial toggle state/dropdown selection
            titleEditor.Text = d;
            colourSelect.SelectedIndex = e;
            switches[0].IsToggled = a;
            switches[1].IsToggled = b;
            switches[2].IsToggled = c;
        }

        public void GC()
        {
            //Adding event handlers
            switches[0].Toggled -= OnToggledXAxis;
            switches[1].Toggled -= OnToggledYAxis;
            switches[2].Toggled -= OnToggledGridLines;

            //Dropdown selection event
            colourSelect.SelectedIndexChanged -= ColourSelectOnSelectedIndexChanged;

            //Editor changed event
            titleEditor.TextChanged -= TitleEditorOnTextChanged;
        }

        private void TitleEditorOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            TitleTyped = titleEditor.Text;
        }

        #region EventHandlers

        private void ColourSelectOnSelectedIndexChanged(object sender, EventArgs args)
        {
            //Sets the property to the picker selected index
            var picker = (Picker)sender;
            ColourPicked = picker.SelectedIndex;
        }

        private void OnToggledXAxis(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                XAxisValue = true;
            }
            else
            {
                XAxisValue = false;
            }
        }
        private void OnToggledYAxis(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                YXaxisValue = true;
            }
            else
            {
                YXaxisValue = false;
            }
        }
        private void OnToggledGridLines(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                GridLinesValues = true;
            }
            else
            {
                GridLinesValues = false;
            }
        }

#endregion
        
            protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        public virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        public virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}
