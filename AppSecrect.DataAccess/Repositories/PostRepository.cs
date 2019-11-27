namespace AppSecrect.DataAccess.Repositories
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppSecrectContext context) : base(context)
        {
        }

        public async Task<List<Post>> ListPostWithComment(DateTime startDate, List<Guid> friendsList)
        {
            return context.Posts
                 .Include(x => x.Comments)
                 .Where(x=>x.Create >= startDate)
                 .Where(x => friendsList.Contains(x.ResponsableId))
                 .ToList();
        }
    }
}
