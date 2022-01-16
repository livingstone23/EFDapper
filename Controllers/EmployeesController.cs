using EFDapper.Models;
using EFDapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {


        private readonly IEmployeeRepository _emploRepo;
        private readonly IBonusRepository _bonRepo;


        [BindProperty]
        public Employee Employee { get; set; }


        public EmployeesController(IEmployeeRepository emploRepo, IBonusRepository bonRepo)
        {
            _emploRepo = emploRepo;
            _bonRepo = bonRepo;
        }


        [HttpGet("{id}")]
        public Employee GeDetails(int id)
        {
            return _emploRepo.Find(id);
        }


        //Metodo con dapper anotations
        //[HttpGet]
        //public async Task<List<Employee>> Index()
        //{
        //    return _emploRepo.GetAll();
        //}


        //Metodo con _bonusrepository
        [HttpGet]
        public async Task<List<Employee>> Index(int companyId = 0)
        {
            List<Employee> employees = _bonRepo.GetEmployeeWithCompany(companyId);
            return employees;
        }



        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Employee employee)
        //{
        //    _emploRepo.Add(employee);
        //    return NoContent();
        //}


        [HttpPost]
        public async Task<IActionResult> Create()
        {
            _emploRepo.Add(Employee);
            return NoContent();
        }


        [HttpPut("{id}")]
        public  async Task<IActionResult> Put(int id)
        {
            _emploRepo.Update(Employee);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _emploRepo.Remove(id);
            return NoContent();
        }


    }
}
