using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding.Model
{
    [Table("tblDepartment")]
    public partial class Department
    {
        public Department()
        { Student = new HashSet<Student>(); }
        [Key]
        public int DepartmentID { get; set; }
        [StringLength(50)]
        public string DepartmanName { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}