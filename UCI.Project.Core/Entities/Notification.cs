using System;

namespace UCI.Project.Domain.Entities
{
    public class Notification : Entity
    {
        public Notification() : base()
        {
            Duration = TimeSpan.FromHours(1);
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return DateTime.Now > DateTime.Add(Duration);
        }


    }
}
