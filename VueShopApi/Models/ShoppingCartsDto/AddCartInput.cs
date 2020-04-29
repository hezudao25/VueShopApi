using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueShopApi.Models.ShoppingCartsDto
{
    public class AddCartInput
    {
        public int Count { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
    }
}
