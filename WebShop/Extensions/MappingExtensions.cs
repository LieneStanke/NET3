using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Logic.DB;
using WebShop.Models;

namespace WebShop
{
    public static class MappingExtensions
    {
        // Mapping (datu translācija no vienas DB klases uz attiecīgo modeli)
        
        public static CategoryModel ToModel(this Categories category)
        {
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
            };
        }

        public static UserModel ToModel(this Users user)
        {
            if(user == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                IsAdmin = user.IsAdmin,
                // Password = user.Password, <- nav nekur jāattēlo, tāpēc nav jāatlasa
            };
        }

        public static ItemModel ToModel(this Items item)
        {
            if (item == null)
            {
                return null;
            }

            return new ItemModel()
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                Price = item.Price,
                Description = item.Description,
                Image = item.Image,
            };
        }
    }
}
