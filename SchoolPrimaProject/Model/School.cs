using System.ComponentModel.DataAnnotations;

namespace SchoolPrimaProject.Model
{
    public class School
    {
        [Key]
        public int School_Id { get; set; }
        public string School_Name{ get; set; }
        public string School_Address{ get; set; }
    }
}
