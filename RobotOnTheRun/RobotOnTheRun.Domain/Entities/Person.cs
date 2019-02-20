using RobotOnTheRun.Domain.Enums;
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
        public GenderEnum Gender { get; set; }
        public DateTime? DateCreated { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
