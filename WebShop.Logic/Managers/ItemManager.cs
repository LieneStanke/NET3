﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
   public class ItemManager
    {
        public static List<Items> GetAll()
        {
             using (var db = new DbContext())
             {
                 return db.Items.OrderBy(c => c.Name).ToList();
             }
        }

        public static List<Items> GetByCategory(int id)
        {
            using(var db = new DbContext())
            {
                return db.Items.Where(c => c.CategoryId == id).OrderBy(i => i.Price).ToList();
            }
        }


        public static void Create(int categoryId, string name, string description, decimal price)
        {
            using (var db = new DbContext())
            {
                db.Items.Add(new Items()
                {
                    CategoryId = categoryId,
                    Name = name,
                    Description = description,
                    Price = price,
                });

                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var db = new DbContext())
            {
                db.Items.Remove(db.Items.Find(id));
                db.SaveChanges();
            }
        }
    }
}
