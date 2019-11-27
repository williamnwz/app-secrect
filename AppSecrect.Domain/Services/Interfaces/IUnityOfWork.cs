
namespace AppSecrect.Domain.Services.Interfaces
{
    using System.Threading.Tasks;


    /// <summary>
    /// IUnityOfWork
    /// </summary>
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
