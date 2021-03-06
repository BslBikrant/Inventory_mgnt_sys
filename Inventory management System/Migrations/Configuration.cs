namespace Inventory_management_System.Migrations
{
    using Inventory_management_System.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inventory_management_System.Db.DefaultDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inventory_management_System.Db.DefaultDbContext db)
        {
            var adminUser = new UserInfo() { Username = "admin@admin.com", Password = "Admin@123", Role = Roles.Admin };
            var normalUser = new UserInfo() { Username = "user@user.com", Password = "User@123", Role = Roles.User };

            if (!db.UserInfos.Any(p => p.Username == adminUser.Username))
            {
                db.UserInfos.Add(adminUser);
                db.SaveChanges();
            }
            if (!db.UserInfos.Any(p => p.Username == normalUser.Username))
            {
                db.UserInfos.Add(normalUser);
                db.SaveChanges();
            }
        }
    }
}