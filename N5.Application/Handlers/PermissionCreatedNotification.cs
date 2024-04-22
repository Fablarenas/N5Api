using MediatR;
using N5.Domain.Entities;

namespace N5.Application.Handlers
{
    public class PermissionCreatedNotification : INotification
    {
        public Permission Permission { get; }

        public PermissionCreatedNotification(Permission permission)
        {
            Permission = permission;
        }
    }
}
