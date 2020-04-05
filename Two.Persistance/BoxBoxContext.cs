using System;
using Boxters.Application.Interfaces;
using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Npgsql;

namespace Boxters.Persistance
{
    public partial class BoxBoxContext : DbContext, IBoxBoxContext
    {
        public BoxBoxContext()
        {
        }

        public BoxBoxContext(DbContextOptions<BoxBoxContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<BranchOffice> BranchOffice { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<FoodType> FoodType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderFoodOperation> OrderFoodOperation { get; set; }
        public virtual DbSet<OrderState> OrderState { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleFood> SaleFood { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                var databaseUri = new Uri(databaseUrl);
                var userInfo = databaseUri.UserInfo.Split(':');

                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/')
                };

                optionsBuilder.UseNpgsql(builder.ToString());
                
                // optionsBuilder.UseNpgsql("Host=localhost;Database=BoxBox;Username=postgres;Password=qwertyAhuel");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.HasSequence<int>("Sales_Id_seq");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoxBoxContext).Assembly);
        }
    }
}
