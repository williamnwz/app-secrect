namespace AppSecrect.Domain.Repositories
{
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> ListPostWithComment(DateTime startDate, List<Guid> friendsList);
    }
}
