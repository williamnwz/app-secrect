namespace AppSecrect.Domain.Services.Interfaces
{
    using AppSecrect.Domain.Entities;
    using System.Threading.Tasks;
    public interface ICreatePost
    {
        Task Create(User responsable, Post post);
    }
}
