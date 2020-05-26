using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class CategoryManager
    {
        public static List<Categories> GetAll()
        {
            // realizēt atlasi no DB
            // izvada visu kategoriju sarakstu no DB: kateg. nosauk., ID un ParentId

            using(var db = new DbContext())
            {
                return db.Categories.OrderBy(c => c.Name).ToList();
            }
        }

        public static Categories Get(int id)
        {
            using(var db = new DbContext())
            {
                return db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }

        public static void Create(string name, int? parentId)
        {
            using(var db = new DbContext())
            {
                db.Categories.Add(new Categories()
                {
                    Name = name,
                    ParentId = parentId,
                });

                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var db = new DbContext())
            {
                db.Categories.Remove(db.Categories.Find(id));
                db.SaveChanges();
            }
        }

        public static int GetItemCount(int id)
        {
            using (var db = new DbContext())
            {
               return  db.Items.Count(c => c.Category.Id == id);
            }
        }
    }
}
