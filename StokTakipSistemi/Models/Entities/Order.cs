using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        // Relational Properties

        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            // Products null değilse ve içinde ürün varsa, ilk ürünü al
            Product product = Products?.FirstOrDefault();

            if (product != null)
            {
                return $" {product.StockQuantity} Adet {product.Name} Sipariş Edilmiştir.";
            }
            else
            {
                return $"{OrderDate:dd.MM.yyyy} - Ürün bilgisi bulunamadı";
            }
        }
    }
}
