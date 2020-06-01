using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            //  realizēt saglabāšanu DB tabulā UserCart
           using(var db = new DbContext())
            {
                db.UserCart.Add(new UserCart()
                {
                    UserId = userId,
                    ItemId = itemId,
                });

                db.SaveChanges();
            }
        }

        public static List<UserCart> GetByUser(int userId)
        {
            using (var db = new DbContext())
            {
                // realizēt datu atlasi no DB tabulas UserCart

                // var userCart = db.UserCart.Where(u => u.UserId == userId).ToList();

                // izm. foreach() katram UserCart ierakstam atlasīt arī preces datus.
                // un pēc itemId atrod attiecīgo item. (info par katru preci)

                // foreach(var item in userCart)
                //   {
                //   item.Item = db.Items.Find(item.ItemId);
                // }

                var userCart = db.UserCart.Where(u => u.UserId == userId)
                    .Join(db.Items, c => c.ItemId, i => i.Id, (c, i) => new UserCart()
                    {
                        Item = i
                    }).ToList();

                // select * from UserCart where UserId = @userId
                // select * from Items where Id = @ItemId1
                // select * from Items where Id = @ItemId2
                // select * from Items where Id = @ItemId3

                // SQL JOIN
                // select * from UserCart c, Items i
                // where c.UserId = @userId AND i.Id = c.ItemId
                // JOIN ir efektīvaks kā cikliska datu atlase

                return userCart;
            }
        }

        public static void DeleteItemFromCart(int id)
        {
            using(var db = new DbContext())
            {
                db.UserCart.Remove(db.UserCart.FirstOrDefault(d => d.ItemId == id));
                db.SaveChanges();
            }
        }

        public static void DeleteAll(int userId, int itemId)
        {
            using (var db = new DbContext())
            {
                db.UserCart.RemoveRange(db.UserCart.Where(u => u.ItemId == itemId && u.UserId == userId));
                db.SaveChanges();
            }
        }
    }
}
