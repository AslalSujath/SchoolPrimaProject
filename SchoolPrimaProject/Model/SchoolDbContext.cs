using Microsoft.EntityFrameworkCore;
using SchoolPrimaProject.Controller;
using SchoolPrimaProject.Data.Configuration;
using SchoolPrimaProject.Model;
using System.Reflection.Metadata;


namespace SchoolPrimaProject.Model
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public DbSet<Marks> Marks { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Studen> Studens { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}


//public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolDbContext>
//{
//    protected override void Seed(SchoolDbContext context)
//    {
//        IList<School> defaultSchool = new List<School>();

//        defaultSchool.Add(new School() { School_Id =1, School_Name = "Maliyadeva College", School_Address= "Kurunegala" });
//        defaultSchool.Add(new School() { School_Id =2, School_Name = "President's College", School_Address= "Panadura" });

//        context.Schools.AddRange(defaultSchool);

//        base.Seed(context);
//    }
//}
