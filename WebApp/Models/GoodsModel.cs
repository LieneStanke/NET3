using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class GoodsModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name: ")]
        public string GoodsName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price: ")]
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        [StringLength(150)]
        [Display(Name = "Location: ")]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Category: ")]
        public string CategoryName { get; set; }

        public CategoriesModel Categories { get; set; }
    }
}
