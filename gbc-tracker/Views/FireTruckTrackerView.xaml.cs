using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using GBC.Tracker.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;

namespace GBC.Tracker;

public partial class FireTruckTrackerView : ContentPage
{
    private readonly ILocationPermissionService _locationPermissionService;
    private readonly ILogger<FireTruckTrackerView> _logger;

    public FireTruckTrackerView(
        ILocationPermissionService locationPermissionService,
        ILogger<FireTruckTrackerView> logger)
    {
        InitializeComponent();
        _locationPermissionService = locationPermissionService;
        _logger = logger;
        Loaded += OnLoaded;

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

    private async void OnLoaded(object? sender, EventArgs e)
    {
        Loaded -= OnLoaded;

        try
        {
            await Task.Yield();
            var status = await _locationPermissionService.RequestWhenInUseAsync();
            TrackerMap.IsShowingUser = status == PermissionStatus.Granted;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unable to enable the map's user location.");
        }
    }
}
