using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Domain.Services.Interfaces
{
    public interface IListPosts
    {
        Task<List<Post>> ListPosts(Guid responsableId);
    }
}
