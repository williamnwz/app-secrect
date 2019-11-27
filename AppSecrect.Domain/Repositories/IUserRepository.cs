namespace AppSecrect.Domain.Repositories
{
    using AppSecrect.Domain.Entities;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// IUserRepository
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdWithFriends(Guid guid);
    }
}
