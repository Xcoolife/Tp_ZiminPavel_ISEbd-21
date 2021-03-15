using Microsoft.EntityFrameworkCore;
using System;
using TreeFactoryDatabaseImplement.Models;

namespace TreeFactoryDatabaseImplement
{
    public class TreeFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ANP4MKQ\SQLEXPRESS;Initial Catalog=TreeFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Wood> Woods { set; get; }
        public virtual DbSet<WoodComponent> WoodComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
