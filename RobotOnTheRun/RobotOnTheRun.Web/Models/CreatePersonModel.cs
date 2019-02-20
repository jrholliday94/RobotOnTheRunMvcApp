﻿using RobotOnTheRun.Domain.Enums;
using System;

namespace RobotOnTheRun.Web.Models
{
    public class CreatePersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}