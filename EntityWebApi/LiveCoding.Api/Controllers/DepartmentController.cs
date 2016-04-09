using LiveCoding.Business;
using LiveCoding.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LiveCoding.Api.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        UnitOfWork work = new UnitOfWork();
        [HttpGet]
        [Route("GetAll")]
        public MobileResult GetDepartments()
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                var departments = work.DepartmentRepository.Get();
                List<Department> departmentList = new List<Department>();
                foreach (Department item in departments)
                {
                    departmentList.Add(new Department() { DepartmentID = item.DepartmentID, DepartmanName = item.DepartmanName });
                }
                result.Data = departmentList;
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
        public MobileResult InsertDepartment(Department model)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.DepartmentRepository.Insert(model);
                work.Save();
                result.Message = "New Department has been added";
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
        public MobileResult DeleteDepartment(Department model)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.DepartmentRepository.Delete(model);
                work.Save();
                result.Message = "Selected Department has been deleted";
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
        public MobileResult UpdateDepartment(Department model)
        {
            MobileResult result = new MobileResult();
            result.Result = true;
            try
            {
                work.DepartmentRepository.Update(model);
                work.Save();
                result.Message = "Selected Department has been updated";
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