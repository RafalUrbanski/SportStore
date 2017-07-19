using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities.Configurations
{
    class ProductsConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductsConfiguration()
        {
            ToTable("Products");

            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasMaxLength(255);

            Property(p => p.Category)
                .HasMaxLength(255);
        }
    }
}
