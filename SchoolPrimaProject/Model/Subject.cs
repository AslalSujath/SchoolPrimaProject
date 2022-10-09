using System.ComponentModel.DataAnnotations;

namespace SchoolPrimaProject.Model
{
    public class Subject
    {
        [Key]
        public int Subject_id { get; set; }
        public string Subject_Name { get; set; }
    }
}
