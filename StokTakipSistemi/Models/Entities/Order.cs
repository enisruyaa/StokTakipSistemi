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

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public override string ToString()
        {
            if (OrderDetails == null || !OrderDetails.Any())
                return "Siparişte ürün yok";

            var detailStrings = OrderDetails
                .Select(od => $"{od.Product.Name} Ürününden --> {od.Quantity} Adet Sipariş Edilmiştir.");

            return string.Join(", ", detailStrings);
        }
    }
}
