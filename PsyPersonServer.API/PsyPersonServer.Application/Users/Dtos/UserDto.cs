﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PsyPersonServer.Application.Users.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Password { get; set; }
        public bool? IsBlocked { get; set; }
        public string Role { get; set; }
        public DateTime? DateBirthday { get; set; }
    }
}
