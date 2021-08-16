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
            return Context.Set<TEntity>().AsQueryable();
        }

        public Task<TEntity> GetById(Guid entityId)
        {
            return null;
        }

        public async Task Addasync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await Task.Run(() => Context.Set<TEntity>().Update(entity));
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}