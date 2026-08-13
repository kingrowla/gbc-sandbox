using Microsoft.Maui.ApplicationModel;

namespace GBC.Tracker.Services;

public sealed class LocationPermissionService : ILocationPermissionService
{
    public async Task<PermissionStatus> RequestWhenInUseAsync()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
        {
            return status;
        }

        return await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
}
