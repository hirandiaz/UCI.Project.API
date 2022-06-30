using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UCI.Project.API.Models;
using UCI.Project.Domain.Core.Data;
using UCI.Project.Domain.Entities;
using UCI.Project.Domain.Repositories;

namespace UCI.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INotificationRepository repository;

        public NotificationsController(IUnitOfWork unitOfWork, INotificationRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            return Ok(await repository.GetAllAsync());
        }


        // POST: api/Notifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostNotification([FromBody] MotificationModel model)
        {
            Notification notification = repository.Create();

            notification.DateTime = model.DateTime;
            notification.UserId = model.UserId;
            notification.Message = model.Message;

            if (model.Duration is { })
                notification.Duration = model.Duration.Value;

            await repository.AddAsync(notification);
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (await NotificationExists(notification.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status201Created, new { id = notification.Id });
        }


        private async Task<bool> NotificationExists(string id)
        {
            return (await repository.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
