using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Models.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; } // Siparişin Toplam Ücreti

        public int Quantity { get; set; } // Sipariş verildiğinde verilen siparişin miktarı

        // Relational Properties

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
