using CommunityToolkit.Mvvm.ComponentModel;
using GBC.Tracker.Services;

namespace GBC.Tracker.ViewModels;

public sealed class AdminViewModel(TrackingShareState trackingShareState)
    : ObservableObject
{
    public TrackingShareState TrackingShareState { get; } = trackingShareState;
}
