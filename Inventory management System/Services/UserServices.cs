using Inventory_management_System.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_System.Services
{
    public class UserServices
    {
        private DefaultDbContext db = new DefaultDbContext();

        public (bool, string) Login(string Username, string Password)
        {
            try
            {
                var exists = db.UserInfos.FirstOrDefault(x => x.Username == Username);
                if (exists == null)
                {
                    return (false, "User not Found");
                }
                else
                {
                    if (exists.Password != Password)
                    {
                        return (false, "Password does not match");
                    }
                    else
                    {
                        return (true, "Password matched");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}