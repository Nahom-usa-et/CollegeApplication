using Microsoft.EntityFrameworkCore;
using CollegeApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApplication.Data.Configuration
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder) 
        {
            builder.ToTable("StudentTable");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.phone).IsRequired();
            builder.Property(x => x.phone).HasMaxLength(50);

            builder.HasData(new List<Student>()
            {
           new Student {Id =1 , Name = "brian" , Email= "br@gmail.com" , phone="122-123-2312",addmisiondate= new DateTime(12/22/2024) , password ="b1234" , ConfirmPassword="b1234"} ,
           new Student {Id =2 , Name = "Simantha" , Email= "simantha@gmail.com" , phone="452-555-8787",addmisiondate= new DateTime(12/23/2024) , password ="si431234" , ConfirmPassword="si431234"}
            }
            );

        }
    }
}
