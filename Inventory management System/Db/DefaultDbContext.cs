using Inventory_management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_System.Db
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("name=Default")
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}