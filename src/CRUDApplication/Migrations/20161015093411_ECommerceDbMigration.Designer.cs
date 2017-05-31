using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CRUDApplication.DbEntities;

namespace CRUDApplication.Migrations
{
    [DbContext(typeof(CRUDContext))]
    [Migration("20161015093411_ECommerceDbMigration")]
    partial class ECommerceDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDApplication.DbEntities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("IPAddress");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MobileNo")
                        .IsRequired();

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });
        }
    }
}
