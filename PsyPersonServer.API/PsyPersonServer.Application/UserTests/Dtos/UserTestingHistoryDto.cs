﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PsyPersonServer.Application.UserTests.Dtos
{
    public class UserTestingHistoryDto
    {
        public Guid Id { get; set; }
        public double TestScore { get; set; }
        public DateTime TestedDate { get; set; }
        public Guid UserTestId { get; set; }
    }
}
