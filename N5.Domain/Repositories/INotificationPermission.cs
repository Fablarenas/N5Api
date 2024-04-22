using N5.Domain.Entities;

namespace N5.Domain.Repositories
{
    public interface INotificationPermission
    {
        Task NotificateAddPermissionAsync(Permission permission);
    }
}
