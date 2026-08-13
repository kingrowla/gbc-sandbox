namespace GBC.Tracker.Services;

public interface ILocalAccessService
{
    Task<LocalAccessResult> CheckAsync(CancellationToken cancellationToken = default);
}
