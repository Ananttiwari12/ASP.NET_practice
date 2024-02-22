using ASP.NET_tut.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_tut.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Students>
    {   

        public void Configure(EntityTypeBuilder<Students>builder)
        {   
            builder.ToTable("Students");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(n=>n.Name).IsRequired();
            builder.Property(n=>n.Name).HasMaxLength(250);
            builder.Property(n=>n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n=>n.Email).IsRequired().HasMaxLength(250);

            builder.HasData([
                new Students{
                    Id=1,
                    Name="Anant",
                    Email="an@gmial.com",
                    Address="katni",
                    DOB=new DateTime(2002,12,12)
                },
                new Students{
                    Id=2,
                    Name="Anant2",
                    Email="an2@gmial.com",
                    Address="katni",
                    DOB=new DateTime(2002,12,12)
                }
            ]);

        }


    }
    
}