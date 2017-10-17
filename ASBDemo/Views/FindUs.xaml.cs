using ASBDemo.Common;
using ASBDemo.Models;
using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASBDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FindUs : Page
    {
        public FindUs()
        {
            this.InitializeComponent();
            Shell.Current.AddCommand(new ShellCommand
            {
                Icon = new SymbolIcon { Symbol = Symbol.Find },
                Label = "Search"
            });
            TryGetLocation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Shell.Current.SetPageName("Find Us");
            base.OnNavigatedTo(e);
        }

        private Geolocator Locator { get; set; }
        private MapIcon MyPosition { get; set; }

        public async void TryGetLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Locator = new Geolocator();
                var location = await Locator.GetGeopositionAsync();
                Locator.PositionChanged += Locator_PositionChanged;

                MyPosition = new MapIcon
                {
                    Location = location.Coordinate.Point,
                    Title = "My Position",
                    NormalizedAnchorPoint = new Point(0, 0)
                };
                TheMap.MapElements.Add(MyPosition);
                TheMap.Center = MyPosition.Location;
                TheMap.ZoomLevel = 15;
            }
        }

        private void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            VisualTools.OnUIThread(Dispatcher, () =>
            {
                MyPosition.Location = args.Position.Coordinate.Point;
            });
        }
    }
}