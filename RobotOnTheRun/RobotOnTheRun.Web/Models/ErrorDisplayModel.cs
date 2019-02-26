using System;

namespace RobotOnTheRun.Web.Models
{
    public class ErrorDisplayModel
    {
        public Guid ErrorId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptions { get; set; }
    }
}