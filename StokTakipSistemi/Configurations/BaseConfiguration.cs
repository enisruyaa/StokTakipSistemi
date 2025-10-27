using StokTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.Configurations
{
    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseConfiguration()
        {
            
        }
    }
}
