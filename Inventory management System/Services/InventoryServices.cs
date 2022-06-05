using Inventory_management_System.Db;
using Inventory_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_System.Services
{
    public class InventoryServices
    {
        private DefaultDbContext db = new DefaultDbContext();

        public List<Inventory> GetAll()
        {
            return db.Inventory.ToList();
        }

        public Inventory GetById(int id)
        {
            return db.Inventory.Find(id);
        }

        public (bool, String) Create(Inventory Models)
        {
            try
            {
                db.Inventory.Add(Models);
                db.SaveChanges();
                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public (bool, String) Edit(Inventory Models)
        {
            try
            {
                var existing = db.Inventory.Find(Models.Id);
                if (existing != null) return (false, "Not Found");

                existing.Description = Models.Description;
                existing.Name = Models.Name;
                existing.Price = Models.Price;
                existing.Stock = Models.Stock;
                existing.DateOfPurchase = Models.DateOfPurchase;
                existing.CategoryId = Models.CategoryId;

                db.Entry(existing).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public (bool, String) Delete(int id)
        {
            try
            {
                var existing = db.Inventory.Find(id);
                if (existing != null) return (false, "Not Found");

                db.Inventory.Remove(existing);

                db.SaveChanges();
                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}