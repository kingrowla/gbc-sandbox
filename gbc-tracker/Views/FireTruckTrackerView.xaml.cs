using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;

namespace GBC.Tracker;

public partial class FireTruckTrackerView : ContentPage
{
    public FireTruckTrackerView()
    {
        InitializeComponent();

        var gulfBreeze = new Location(30.3571, -87.1639);
        TrackerMap.Pins.Add(new Pin
        {
            Label = "Fire Truck",
            Address = "Gulf Breeze, FL 32561",
            Location = gulfBreeze,
            Type = PinType.Place
        });

        TrackerMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            gulfBreeze,
            Distance.FromMiles(3)));
    }
}
