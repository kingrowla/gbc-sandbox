using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GBC.Tracker.Services;

namespace GBC.Tracker.ViewModels;

public partial class HomeViewModel(
    INavigationService navigationService,
    ILocalAccessService localAccessService,
    IAlertService alertService) : ObservableObject
{
    private bool _hasInitialized;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(OpenFireTruckTrackerCommand))]
    [NotifyCanExecuteChangedFor(nameof(OpenBandTrackerCommand))]
    private bool isLocalAccessEnabled;

    public async Task InitializeAsync()
    {
        if (_hasInitialized)
        {
            return;
        }

        try
        {
            var result = await localAccessService.CheckAsync();
            IsLocalAccessEnabled = result == LocalAccessResult.Allowed;

            if (result == LocalAccessResult.OutsideServiceArea)
            {
                await alertService.ShowAsync(
                    "Outside service area",
                    "This location app is intended for local users at this time.",
                    "OK");
            }
        }
        finally
        {
            _hasInitialized = true;
        }
    }

    [RelayCommand(CanExecute = nameof(IsLocalAccessEnabled))]
    private Task OpenFireTruckTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.FireTruckTracker);

    [RelayCommand(CanExecute = nameof(IsLocalAccessEnabled))]
    private Task OpenBandTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.BandTracker);
}
