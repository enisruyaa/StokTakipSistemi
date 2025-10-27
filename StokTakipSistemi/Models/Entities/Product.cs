using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public override string ToString()
        {
            string urunAdlari = Orders != null && Orders.Any()
        ? string.Join(" | ", Orders.Select(m => m.TotalAmount))
        : "Ürün Yok";
            return $"{Name} Ürününün Fiyatı :{Price}   Stok Miktarı -> {StockQuantity} ";
        }

        // Relational Properties

        public ICollection<Order> Orders { get; set; }
    }
}
