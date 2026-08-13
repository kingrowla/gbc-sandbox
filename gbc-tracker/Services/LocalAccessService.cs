using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace GBC.Tracker.Services;

public sealed class LocalAccessService(
    ILocationPermissionService locationPermissionService) : ILocalAccessService
{
    // Approximate center of Gulf Breeze ZIP code 32561.
    private static readonly Location ServiceAreaCenter = new(30.3571, -87.1639);

    private const double ServiceRadiusMiles = 50;

    public async Task<LocalAccessResult> CheckAsync(
        CancellationToken cancellationToken = default)
    {
        var permission = await locationPermissionService.RequestWhenInUseAsync();

        if (permission != PermissionStatus.Granted)
        {
            return LocalAccessResult.PermissionDenied;
        }

        try
        {
            var request = new GeolocationRequest(
                GeolocationAccuracy.Medium,
                TimeSpan.FromSeconds(15));

            var location = await Geolocation.Default.GetLocationAsync(
                request,
                cancellationToken);

            if (location is null)
            {
                return LocalAccessResult.LocationUnavailable;
            }

            var distanceMiles = Location.CalculateDistance(
                ServiceAreaCenter,
                location,
                DistanceUnits.Miles);

            return distanceMiles <= ServiceRadiusMiles
                ? LocalAccessResult.Allowed
                : LocalAccessResult.OutsideServiceArea;
        }
        catch (FeatureNotEnabledException)
        {
            return LocalAccessResult.LocationUnavailable;
        }
        catch (FeatureNotSupportedException)
        {
            return LocalAccessResult.LocationUnavailable;
        }
        catch (PermissionException)
        {
            return LocalAccessResult.PermissionDenied;
        }
        catch (OperationCanceledException)
        {
            return LocalAccessResult.LocationUnavailable;
        }
    }
}
