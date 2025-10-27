using StokTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Configurations
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.ProductID,
                x.OrderID
            });
        }
    }
}
