using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolPrimaProject.Model;
using System.Reflection.Emit;

namespace SchoolPrimaProject.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                     new Subject()
                     {
                         Subject_id = 1,
                         Subject_Name = "Art"
                     },
                     new Subject()
                     {
                         Subject_id = 2,
                         Subject_Name = "Sinhala"
                     },
                      new Subject()
                      {
                          Subject_id = 3,
                          Subject_Name = "Maths"
                      }
               );
        }
    }
}
