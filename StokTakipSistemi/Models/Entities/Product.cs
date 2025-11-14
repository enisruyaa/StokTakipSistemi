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

        public string StockStatus
        {
            get
            {
                if (StockQuantity < 5) return "Low";
                else if (StockQuantity < 20) return "Medium";
                else return "High";
            }
        }

        public override string ToString()
        {
            string result = $"{Name} Ürününün Fiyatı :{Price}   Stok Miktarı -> {StockQuantity} ";
            return result;
        }

        // Relational Properties

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
