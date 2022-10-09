using System.ComponentModel.DataAnnotations;

namespace SchoolPrimaProject.Model
{
    public class Marks
    {
        [Key]
        public int id { get; set; }
        public double Marks_Value { get; set; }
        public int Student_Id { get; set; }
        public int Subject_id { get; set; }
    }
}
