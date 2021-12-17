﻿using Microsoft.EntityFrameworkCore;
using PsyPersonServer.Domain.Entities;
using PsyPersonServer.Domain.Models.PagedResponse;
using PsyPersonServer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsyPersonServer.Infrastructure.Repositories
{
    public class UserTestRepository : IUserTestRepository
    {
        public UserTestRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly DBContext _dbContext;

        public Task<IEnumerable<UserTest>> GetUserTestsByUserId(string userId)
        {
            var userTests = _dbContext.UserTests.Where(x => x.UserId == userId);
            return Task.FromResult<IEnumerable<UserTest>>(userTests);
        }

        public async Task<PagedResponse<UserTest>> GetUserTests(int page, int itemPerPage, string userId)
        {
            var userTests = _dbContext.UserTests
                .Include(x => x.TestFk)
                .Include(x => x.UserTestingHistoryList).Where(x => x.UserId == userId).AsQueryable();

            var total = await userTests.CountAsync();

            return new PagedResponse<UserTest>(userTests
                .OrderByDescending(x => x.AssignedDate)
                .Skip((page - 1) * itemPerPage)
                .Take(itemPerPage), total);
        }

        public async Task<UserTest> GetUserTest(string userId, Guid testId)
        {
            var userTests = await _dbContext.UserTests.FirstOrDefaultAsync(x => x.UserId == userId && x.TestId == testId);
            if(userTests != null)
                return userTests;
            return new UserTest();
        }

        public async Task<UserTest> Create(string userId, Guid testId)
        {
            var userTest = new UserTest
            {
                Id = new Guid(),
                IsActive = true,
                IsTested = false,
                UserId = userId,
                TestId = testId,
                AssignedDate = DateTime.Now
            };

            await _dbContext.UserTests.AddAsync(userTest);
            await _dbContext.SaveChangesAsync();

            return userTest;
        }

        public async Task<bool> Update(Guid id, bool isActive, bool isTested, DateTime assignedDate)
        {
            var userTest = await _dbContext.UserTests.FirstOrDefaultAsync(x => x.Id == id);

            if (userTest != null)
            {
                userTest.IsActive = isActive;
                userTest.IsTested = isTested;
                userTest.AssignedDate = assignedDate;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
