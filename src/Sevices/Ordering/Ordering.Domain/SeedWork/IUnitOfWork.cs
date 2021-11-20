using System.Threading.Tasks;

namespace Ordering.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
