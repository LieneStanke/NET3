using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Display(Name = "Parent id: ")]
        public int? ParentId { get; set; }

        public int ItemCount { get; set; }
    }
}
