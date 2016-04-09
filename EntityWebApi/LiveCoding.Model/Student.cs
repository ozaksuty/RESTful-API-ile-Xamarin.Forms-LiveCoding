using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding.Model
{
    [Table("tblStudent")]
    public partial class Student
    {
        public Student()
        {
            RegistrationDate = DateTime.Now;
        }
        [Key]
        public int StudentID { get; set; }
        public int? DepartmentID { get; set; }
        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        [StringLength(int.MaxValue)]
        public string About { get; set; }
        public bool isDeleted { get; set; } = false;
        public virtual Department Department { get; set; }
    }
}