using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApi.Models
{
    public class Student
    {
        public string FirstCharacter
        {
            get
            {
                if (!String.IsNullOrEmpty(Name))
                {
                    return Name.Substring(0, 1).ToUpper();
                }
                else
                {
                    return "";
                }
            }
        }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string About { get; set; }
        public bool isDeleted { get; set; }
        public int DepartmentID { get; set; }
    }
}
