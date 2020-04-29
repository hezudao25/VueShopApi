using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueShopApi.Entities
{
    public class ShoppingCarts
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }

        public Products product { get; set; }

    }
}
