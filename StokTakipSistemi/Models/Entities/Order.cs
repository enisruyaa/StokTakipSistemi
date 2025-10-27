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
    }
}
