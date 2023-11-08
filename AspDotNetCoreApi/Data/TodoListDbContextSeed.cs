using AspDotNetCoreApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace AspDotNetCoreApi.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(MyDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Trần",
                    LastName = "Thanh Nguyên",
                    Email = "ttnguyen0936@gmail.com",
                    PhoneNumber = "0963496240",
                    UserName = "nguyen"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Nguyen@0936");
                context.Users.Add(user);
            }

            if (context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreateDate = DateTime.Now,
                    Priority = Enums.Priority.High,
                    Status = Enums.Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
