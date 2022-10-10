using SchoolPrimaProject.Model;

namespace SchoolPrimaProject.Data
{
    public class DataSeeder
    {
        private readonly SchoolDbContext schoolDbContext;

        public DataSeeder(SchoolDbContext schoolDbContext)
        {
            this.schoolDbContext = schoolDbContext;
        }

        public void Seed()
        {
            if (!schoolDbContext.Schools.Any())
            {
                var school = new List<School>()
                {
                        new School()
                        {
                            School_Id= 1,
                            School_Name= "Maliyadeva  College",
                            School_Address= "Kurunegala"
                        },
                        new School()
                       {
                             School_Id= 2,
                             School_Name= "President s College",
                             School_Address="Panadura"
                        }
                };

                schoolDbContext.Schools.AddRange(school);
                schoolDbContext.SaveChanges();
            }
        //    if (!schoolDbContext.Subjects.Any())
        //    {
        //        var sub = new List<Subject>()
        //        {
        //                new Subject()
        //                {
        //                 Subject_id= 1,
        //                 Subject_Name="Art"
        //                },
        //                 new Subject()
        //                {
        //                 Subject_id= 2,
        //                 Subject_Name="Sinhala"
        //                },
        //                  new Subject()
        //                {
        //                 Subject_id= 3,
        //                 Subject_Name="Maths"
        //                }
        //};

        //        schoolDbContext.Subjects.AddRange(sub);
        //        schoolDbContext.SaveChanges();
        //    }

        }
    }
}
