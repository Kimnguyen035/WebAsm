using AspDotNetCoreApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspDotNetCoreApi.Data
{
    public class MyDbContext: IdentityDbContext<User, Role, Guid> //DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
