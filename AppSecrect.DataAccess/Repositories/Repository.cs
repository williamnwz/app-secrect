namespace AppSecrect.DataAccess.Repositories
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// BaseRepository
    /// </summary>
    public class Repository<T> : IUnityOfWork, IRepository<T> where T : Entity
    {
        protected readonly AppSecrectContext context;

        public Repository(AppSecrectContext context)
        {
            this.context = context;
        }

        public async Task<List<T>> FindAsync(Func<T, bool> func)
        {
            return context.Set<T>().Where(func).ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task RemoveAsync(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.GenerateId();
                await context.Set<T>().AddAsync(entity);
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }
        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}
