using Inventory_management_System.Db;
using Inventory_management_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_management_System.Services
{
    public class CategoryServices
    {
        private DefaultDbContext db = new DefaultDbContext();

        public List<Category> GetAll()
        {
            return db.Category.ToList();
        }
    }
}