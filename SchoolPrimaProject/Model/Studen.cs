using System.ComponentModel.DataAnnotations;

namespace SchoolPrimaProject.Model
{
    public class Studen
    {
        [Key]
        public int Student_id { get; set; }
        public string Student_Name { get; set; }
        public DateTime Student_Dob { get; set; }
        public int Student_Grade { get; set; }

        public int School_Id { get; set; }
    }
}
