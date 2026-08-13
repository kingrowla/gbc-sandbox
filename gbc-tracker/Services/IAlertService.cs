namespace GBC.Tracker.Services;

public interface IAlertService
{
    Task ShowAsync(string title, string message, string cancel);
}
