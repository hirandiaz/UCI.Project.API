using System.Threading.Tasks;
using UCI.Project.Domain.Core.Data;
using UCI.Project.Infraestructure.Data.Context;

namespace UCI.Project.Infraestructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
