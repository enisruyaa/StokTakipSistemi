using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi.Models.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; } // Siparişin Toplam Ücreti

        public int Quantity { get; set; } // Sipariş verildiğinde verilen siparişin miktarı

        // Relational Properties

        public Order Order { get; set; }

        public Product Product { get; set; }


    }
}
