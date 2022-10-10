using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolPrimaProject.Model;
using System.Reflection.Emit;

namespace SchoolPrimaProject.Data.Configuration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasData(
                     new School()
                     {
                         School_Id = 1,
                         School_Name = "Maliyadeva  College",
                         School_Address = "Kurunegala"
                     },
                     new School()
                     {
                         School_Id = 2,
                         School_Name = "President s College",
                         School_Address = "Panadura"
                     }
                );
        }
    }
}
