using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace database_vue.Model
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Pricing { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public int Shippingcost { get; set; }
    }
}
