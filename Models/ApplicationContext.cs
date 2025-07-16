﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    
    public class ApplicationContext : DbContext
    {
        public DbSet<Contacts> contacts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
