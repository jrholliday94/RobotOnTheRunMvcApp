using System;
using System.ComponentModel.DataAnnotations;

namespace RobotOnTheRun.Domain.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime? DateCreated { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
