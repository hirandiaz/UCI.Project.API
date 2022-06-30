using System.Threading.Tasks;

namespace UCI.Project.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
