namespace GBC.Tracker.Services;

public sealed class ShellAlertService : IAlertService
{
    public Task ShowAsync(string title, string message, string cancel) =>
        Shell.Current.DisplayAlertAsync(title, message, cancel);
}
