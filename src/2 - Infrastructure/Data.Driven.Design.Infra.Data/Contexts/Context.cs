using System;
using Data.Driven.Design.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Driven.Design.Infra.Data.Contexts
{
    public class Context : DbContext
    {
       
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<CustumerEntity> Custumer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
