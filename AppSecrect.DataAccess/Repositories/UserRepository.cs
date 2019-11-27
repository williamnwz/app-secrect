
namespace AppSecrect.DataAccess.Repositories
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// UserRepository
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppSecrectContext context) : base(context)
        {
        }

        public async Task<User> GetUserByIdWithFriends(Guid id)
        {
            return this.context.Users
                .Include(u => u.MainUserFriends)
                .Include(u => u.Friends)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
