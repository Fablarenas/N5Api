using AutoMapper;
using N5.Domain.Entities;
using N5.Domain.Repositories;
using N5.Infraestructure.DbEntities;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace N5.Infraestructure.Repositories
{
    public class NotificationPermission : INotificationPermission
    {
        private readonly IElasticClient _elasticClient;
        private readonly IMapper _mapper;
        public NotificationPermission(IElasticClient elasticClient, IMapper mapper)
        {
            _elasticClient = elasticClient;
            _mapper = mapper;
        }
        public async Task NotificateAddPermissionAsync(Permission permission)
        {
            var permissionNotification = _mapper.Map<PermissionEntity>(permission);
            var response = await _elasticClient.IndexDocumentAsync(permissionNotification);
            if (!response.IsValid)
            {
            }
        }
    }
}
