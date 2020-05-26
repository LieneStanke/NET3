using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Logic
{
    public class ItemManager
    {
        public static List<Goods> GetAllItems()
        {
            using (var db = new DB())
            {

                return db.Goods.OrderBy(i => i.Price).ToList();
            }
        }

        public static Goods GetItem(int id)
        {
            using (var db = new DB())
            {
                
                return db.Goods.Find(id);
            }
        }

        public static void CreateNewItem(string name, decimal price, string description, string location)
        {
            using (var db = new DB())
            {
                db.Goods.Add(new Goods()
                {
                    GoodsName = name,
                    Price = price,
                    Description = description,
                    Location = location,
                });

                db.SaveChanges();
            }
        }
    }
}
