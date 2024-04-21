using System;
using System.Threading.Tasks;

namespace N5.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository Permissions { get; }
        IPermissionTypeRepository PermissionTypes { get; }
        Task<int> CompleteAsync();
    }
}