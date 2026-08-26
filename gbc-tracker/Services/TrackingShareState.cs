using CommunityToolkit.Mvvm.ComponentModel;

namespace GBC.Tracker.Services;

public partial class TrackingShareState : ObservableObject
{
    [ObservableProperty]
    private bool isSharingLocation;
}
