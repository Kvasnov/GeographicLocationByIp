using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeographicLocationByIp.Application.Common.Interfaces.Repositories.Common
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid entityId);
        Task Addasync(TEntity entity);
        Task Update(TEntity entity);
        Task SaveAsync();
    }
}