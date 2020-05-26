using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Logic
{
    public class CategoryManager
    {
        public static List<CategoriesTrue> GetAllCategories()
        {
            using(var db = new DB())
            {
                return db.CategoriesTrue.OrderBy(c => c.Name).ToList();
            }
        }

        public static CategoriesTrue GetCategory(int id)
        {
            using(var db = new DB())
            {
                return db.CategoriesTrue.Find(id);
            }
        }

        public static void CreateNewCategory(string name)
        {
            using(var db = new DB())
            {
                db.CategoriesTrue.Add(new CategoriesTrue()
                {
                    Name = name,
                });

                db.SaveChanges();
            }
        }
    }
}
