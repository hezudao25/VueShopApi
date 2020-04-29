using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueShopApi.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public double OrgPrice { get; set; }
        public string Decoration { get; set; }
        public string Sizes { get; set; }
        public int ClickTimes { get; set; }
        public int SaleTimes { get; set; }
        public bool IsDel { get; set; }
    }
}
