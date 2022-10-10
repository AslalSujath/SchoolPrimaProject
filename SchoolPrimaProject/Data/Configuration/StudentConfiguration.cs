using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPrimaProject.Model;

namespace SchoolPrimaProject.Data.Configuration
{
    public class StudentConfiguration:IEntityTypeConfiguration<Studen>
    {
        public void Configure(EntityTypeBuilder<Studen> builder)
        {
            throw new NotImplementedException();
        }
    }
}
