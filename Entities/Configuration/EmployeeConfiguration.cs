using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee 
                { 
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 
                    Name = "Sam Raiden", 
                    Age = 26, 
                    Position = "Software developer", 
                    CompanyId = new Guid("15D4972D-303F-48AA-8A40-7CBCEE9E6745") }, 
                
                new Employee 
                { Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 
                    Name = "Jana McLeaf", 
                    Age = 30, 
                    Position = "Software developer", 
                    CompanyId = new Guid("15D4972D-303F-48AA-8A40-7CBCEE9E6745") }, 
                new Employee 
                { Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 
                    Name = "Kane Miller", 
                    Age = 35, 
                    Position = "Administrator", 
                    CompanyId = new Guid("62008AF9-BCE9-4AD5-BE1D-97AA332501DB") }
                );
        }
    }
}
