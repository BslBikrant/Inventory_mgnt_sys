using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_System.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public String Password { get; set; }

        public Roles Role { get; set; }
    }

    public enum Roles
    {
        User,
        Admin
    }
}