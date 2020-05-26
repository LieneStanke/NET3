using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category id: ")]
        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Price: ")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Description: ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Image { get; set; }

        public int ItemCount { get; set; }
    }
}
