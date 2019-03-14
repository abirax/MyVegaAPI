using System.Threading.Tasks;

namespace MyVegaApi.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}