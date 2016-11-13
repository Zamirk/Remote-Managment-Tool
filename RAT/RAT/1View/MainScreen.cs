using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class MainScreen : ContentPage
    {
        private ContentView grayView;
        private ContentView redView;
        private ContentView yellowView;

        private ContentView greenView;
        private ContentView tealView;
        private ContentView aquaView;

        private ContentView blackView;
        private ContentView blueView;
        private ContentView maroonView;

        private bool colorOn = true;

        public MainScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Button myButton = new Button();
            {
                Grid grid = new Grid
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto},
                        new RowDefinition {Height = GridLength.Auto},
                        new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                        new RowDefinition {Height = new GridLength(100, GridUnitType.Absolute)}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = GridLength.Auto},
                        new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition {Width = new GridLength(100, GridUnitType.Absolute)}
                    }
                };
                SfDataGrid sDataGrid;
                sDataGrid = new SfDataGrid();
                sDataGrid.ItemsSource = new OrderInfoRepository().OrderInfoCollection;

                //Layout
                StackLayout myLayout = new StackLayout();
                myLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                myLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

                sDataGrid.AllowDraggingColumn = true;
                sDataGrid.AutoExpandGroups = true;
                sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

                sDataGrid.ColumnSizer = ColumnSizer.Auto;



                grid.Children.Add(new Label
                {
                    Text = "Grid",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                }, 0, 3, 0, 1);

                grid.Children.Add(new Label
                {
                    Text = "Autosized cell",
                    TextColor = Color.White,
                    BackgroundColor = Color.Blue
                }, 0, 1);

                grid.Children.Add(new BoxView
                {
                    Color = Color.Silver,
                    HeightRequest = 0
                }, 1, 1);

                grid.Children.Add(new BoxView
                {
                    Color = Color.Teal
                }, 0, 2);

                grid.Children.Add(new Label
                {
                    Text = "Leftover space",
                    TextColor = Color.Purple,
                    BackgroundColor = Color.Aqua,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                }, 1, 2);

                grid.Children.Add(new Label
                {
                    Text = "Span two rows (or more if you want)",
                    TextColor = Color.Yellow,
                    BackgroundColor = Color.Navy,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, 3, 1, 3);

                grid.Children.Add(new Label
                {
                    Text = "Span 2 columns",
                    TextColor = Color.Blue,
                    BackgroundColor = Color.Yellow,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, 2, 3, 4);

                grid.Children.Add(new Label
                {
                    Text = "Fixed 100x100",
                    TextColor = Color.Aqua,
                    BackgroundColor = Color.Red,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, 3);

                grid.Children.Add(sDataGrid, 1, 2);

                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                // Build the page.
                this.Content = grid;
            }
        }
    }
}
