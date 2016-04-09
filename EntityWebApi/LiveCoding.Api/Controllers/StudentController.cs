using LiveCoding.Business;
using LiveCoding.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LiveCoding.Api.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        UnitOfWork work = new UnitOfWork();
        [Route("GetAll")]
        public MobileResult GetStudents()
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                var students = work.StudentRepository.Get();
                List<Student> studentList = new List<Student>();
                foreach (Student item in students)
                {
                    studentList.Add(new Student() { StudentID = item.StudentID, About = item.About, BirthDate = item.BirthDate, DepartmentID = item.DepartmentID, isDeleted = item.isDeleted, Name = item.Name, RegistrationDate = item.RegistrationDate, Surname = item.Surname });
                }
                result.Data = studentList;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Insert")]
        public MobileResult InsertStudent(Student model)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.StudentRepository.Insert(model);
                work.Save();
                result.Message = "New Student has been added";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Delete")]
        public MobileResult DeleteStudent(int ID)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.StudentRepository.Delete(ID);
                work.Save();
                result.Message = "Selected Student has been deleted";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Update")]
        public MobileResult UpdateStudent(Student model)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.StudentRepository.Update(model);
                work.Save();
                result.Message = "Selected Student has been updated";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}