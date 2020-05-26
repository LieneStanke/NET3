using System;
using System.Collections.Generic;

namespace WebApp.Logic
{
    public partial class Goods
    {
        public int Id { get; set; }
        public string GoodsName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
    }
}
