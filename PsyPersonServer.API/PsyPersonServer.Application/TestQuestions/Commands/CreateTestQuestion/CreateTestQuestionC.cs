﻿using MediatR;
using PsyPersonServer.Application.TestQuestions.Dtos;
using PsyPersonServer.Domain.Models.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace PsyPersonServer.Application.TestQuestions.Commands.CreateTestQuestion
{
    public class CreateTestQuestionC : IRequest<TestQuestionDto>
    {
        public string Name { get; set; }
        public Guid TestId { get; set; }
        public List<TestQuestionAnswerDto> Answers { get; set; }
    }
}
