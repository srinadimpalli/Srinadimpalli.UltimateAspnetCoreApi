using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id= new Guid("15D4972D-303F-48AA-8A40-7CBCEE9E6745"),
                    Name = "IT Solutions Ltd",
                    Address = "123 State St, NY 15235",
                    Country ="USA"
                },
                new Company
                {
                    Id= new Guid("62008AF9-BCE9-4AD5-BE1D-97AA332501DB"),
                    Name = "Microsoft Solution",
                    Address = "100 Microsoft street, CA 1201",
                    Country ="USA"
                }
                );
        }
    }
}
