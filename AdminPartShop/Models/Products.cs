using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPartShop.Models
{
    public class Products
    {
        public string Name_Product { get; set; }
        public string Price { get; set; }
        public int Count_Product { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public int Rating { get; set; }
    }
}
