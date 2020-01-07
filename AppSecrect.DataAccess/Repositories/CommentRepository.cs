using AppSecrect.Domain.Entities;
using AppSecrect.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.DataAccess.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppSecrectContext context) : base(context)
        {
        }
    }
}
