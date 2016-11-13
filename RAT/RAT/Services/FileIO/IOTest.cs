using System;
using Xamarin.Forms;

namespace RAT.IO
{
    public class IOTest : ContentPage
    {
        FileHelper.FileHelper fileHelper = new FileHelper.FileHelper();

        private ListView myListView;
        private Editor myEditor;
        private Entry nameEntry;
        private Button myButton;

        public IOTest()
        {
            var mainGrid = new Grid();
            ContentView grayView = new ContentView();
            ContentView redView = new ContentView();
            ContentView greenView = new ContentView();
            ContentView blueView = new ContentView();

            grayView.BackgroundColor = Color.Gray;
            redView.BackgroundColor = Color.Red;
            greenView.BackgroundColor = Color.Green;
            blueView.BackgroundColor = Color.Blue;

            mainGrid.Children.Add(grayView, 0, 0);
            mainGrid.Children.Add(redView, 0, 1);
            mainGrid.Children.Add(greenView, 0, 2);
            mainGrid.Children.Add(blueView, 0, 3);

            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});

            //Entry
            nameEntry = new Entry();
            nameEntry.HorizontalOptions = LayoutOptions.Start;
            nameEntry.VerticalOptions = LayoutOptions.Start;
            nameEntry.Margin = new Thickness(10, 25, 50, 10);
            nameEntry.WidthRequest = 100;
            nameEntry.HeightRequest = 100;
            mainGrid.Children.Add(nameEntry, 0, 0);
            nameEntry.Placeholder = "Filename";

            //Entry 2
            Entry nameEntry2 = new Entry();
            nameEntry2.HorizontalOptions = LayoutOptions.Start;
            nameEntry2.VerticalOptions = LayoutOptions.Start;
            nameEntry2.Margin = new Thickness(120, 25, 50, 10);
            nameEntry2.WidthRequest = 100;
            nameEntry2.HeightRequest = 25;
            //mainGrid.Children.Add(nameEntry2, 0, 0);
            nameEntry2.Placeholder = "Filename 2";

            //Editor
            myEditor = new Editor();
            myEditor.HorizontalOptions = LayoutOptions.FillAndExpand;
            myEditor.VerticalOptions = LayoutOptions.FillAndExpand;
            myEditor.Margin = new Thickness(25, 25, 25, 25);
            myEditor.BackgroundColor = Color.White;
            //myEditor.WidthRequest = 500;
            //myEditor.HeightRequest = 75;
            mainGrid.Children.Add(myEditor, 0, 1);

            //Button
            myButton = new Button();
            myButton.Text = "Save";
            myButton.HorizontalOptions = LayoutOptions.FillAndExpand;
            myButton.VerticalOptions = LayoutOptions.FillAndExpand;
            myButton.Margin = new Thickness(25, 25, 25, 25);
            ////myButton.WidthRequest = 2000;
            //myButton.HeightRequest = 2000;
            myButton.BorderRadius = 25;
            myButton.BorderColor = Color.Black;
            myButton.BackgroundColor = Color.Gray;
            myButton.TextColor = Color.White;
            myButton.Clicked += OnSaveButtonClicked;
            mainGrid.Children.Add(myButton, 0, 2);

            //ListView
            myListView = new ListView();

            //myListView
            DataTemplate myDataTemplate = new DataTemplate(() =>
            {
                TextCell myCell = new TextCell();
                myCell.SetBinding(TextCell.TextProperty, new Binding("."));

                //Delete menu
                var deleteAction = new MenuItem {Text = "Delete", IsDestructive = true}; // red background
                deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                deleteAction.Clicked += OnDeleteMenuItemClicked;
                myCell.ContextActions.Add(deleteAction);

                return myCell;
            });
            myListView.ItemTemplate = myDataTemplate;
            myListView.ItemSelected += OnFileListViewItemSelected;
            myListView.IsPullToRefreshEnabled = true;
            mainGrid.Children.Add(myListView, 0, 3);
            RefreshListView();

            Content = mainGrid;
        }

        async void OnSaveButtonClicked(object sender, EventArgs args)
        {
            myButton.IsEnabled = false;
            string filename = nameEntry.Text;
            if (await fileHelper.ExistsAsync(filename))
            {
                bool okResponse = await DisplayAlert("TextFileTryout",
                    "File " + filename +
                    " already exists. Replace it?",
                    "Yes", "No");
                if (!okResponse)
                    return;
            }
            string errorMessage = null;
            try
            {
                await fileHelper.WriteTextAsync(nameEntry.Text, myEditor.Text);
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }
            if (errorMessage == null)
            {
                nameEntry.Text = "";
                myEditor.Text = "";
                RefreshListView();
            }
            else
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
            myButton.IsEnabled = true;
        }

        async void OnFileListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null)
                return;
            string filename = (string) args.SelectedItem;
            string errorMessage = null;
            try
            {
                myEditor.Text = await fileHelper.ReadTextAsync((string) args.SelectedItem);
                nameEntry.Text = filename;
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }
            if (errorMessage != null)
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
        }

        async void OnDeleteMenuItemClicked(object sender, EventArgs args)
        {
            string filename = (string) ((MenuItem) sender).BindingContext;
            await fileHelper.DeleteAsync(filename);
            RefreshListView();
        }

        async void RefreshListView()
        {
            myListView.ItemsSource = await fileHelper.GetFilesAsync();
            myListView.SelectedItem = null;
        }
    }
}