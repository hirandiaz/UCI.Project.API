using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UCI.Project.Domain.Entities;
using UCI.Project.Domain.Repositories;
using UCI.Project.Infraestructure.Data.Context;

namespace UCI.Project.Infraestructure.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public NotificationRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public async Task AddAsync(Notification entity)
        {
            await dbContext.Set<Notification>().AddAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Notification Create()
        {
            return new Notification();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Notification>> GetAllAsync(Expression<Func<Notification, bool>> expression = null)
        {
            var query = dbContext.Set<Notification>()
                      .AsNoTracking();
            if (expression != null)
                query = query.Where(expression);

            return await
                query
                .OrderByDescending(e => e.DateTime)
                .ToListAsync();
        }

    }
}
