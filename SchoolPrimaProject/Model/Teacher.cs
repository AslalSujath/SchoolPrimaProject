using System.ComponentModel.DataAnnotations;

namespace SchoolPrimaProject.Model
{
    public class Teacher
    {
        [Key]
        public int Teacher_id { get; set; }
        public string Teacher_Name { get; set; }
        public int School_Id { get; set; }
        public int Subject_id { get; set; }
    }
}
