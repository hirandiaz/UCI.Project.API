using System;

namespace UCI.Project.API.Models
{
    public class MotificationModel
    {

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
        public TimeSpan? Duration { get; set; }
    }
}
