using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.DbEntities
{
    public class CustomerMap 
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);            
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.MobileNo).IsRequired();           
        }
    }
}
