
namespace AppSecrect.Domain.Repositories
{
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// IRepository
    /// </summary>
    public interface IRepository<T> where T : Entity
    {
        Task SaveAsync(T entity);
        Task RemoveAsync(T entity);
        Task<List<T>> FindAsync(Func<T, bool> func);
        Task<T> GetByIdAsync(Guid id);
    }
}
