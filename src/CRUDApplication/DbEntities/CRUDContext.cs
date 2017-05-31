using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CRUDApplication.DbEntities
{
    public class CRUDContext:DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CustomerMap(modelBuilder.Entity<Customer>());
        }
    }
}
