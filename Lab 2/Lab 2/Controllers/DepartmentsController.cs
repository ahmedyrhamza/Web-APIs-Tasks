using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL;
using TicketSystem.BL.Dtos;

namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsManager departmentsManager;

        public DepartmentsController(IDepartmentsManager departmentsManager) {
            this.departmentsManager = departmentsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentsReadDto>> GetAll()
        {
            var Departments = departmentsManager.GetAllDepartments();
            if (!Departments.Any())
            {
                return NotFound();
            }
            return Departments;
        }

        [HttpGet]
        [Route("id")]
        public ActionResult<DepartmentDetailsReadDto> GetDetails(int id)     
        {
            var dept = departmentsManager.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return dept;
        }
    }
}
