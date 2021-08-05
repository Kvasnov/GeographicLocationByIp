using System;
using System.Linq;
using System.Threading.Tasks;
using GeographicLocationByIp.Application.Common.Interfaces.Repositories.Common;

namespace GeographicLocationByIp.Infrastructure.Repositories.Common
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        public EntityRepository(DatabaseContext.DatabaseContext context)
        {
            Context = context;
        }

        protected readonly DatabaseContext.DatabaseContext Context;

        public IQueryable<TEntity> GetAll()
        {
            return null;
        }

        public Task<TEntity> GetById(Guid entityId)
        {
            return null;
        }

        public async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public Task Update(TEntity entity)
        {
            return null;
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}