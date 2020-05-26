using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Logic;
using WebApp.Models;

namespace WebApp
{
    public static class MappingExtensions
    {
        public static CategoriesModel ToModel(this CategoriesTrue c)
        {
            return new CategoriesModel()
            {
                Id = c.Id,
                Name = c.Name,
            };
        }

        public static GoodsModel ToModel(this Goods i)
        {
            return new GoodsModel()
            {
                GoodsName = i.GoodsName,
                Price = i.Price,
                Description = i.Description,
                Location = i.Location,
                Id = i.Id,
               // CategoryName = i.CategoryId,
            };
        }
    }
}
