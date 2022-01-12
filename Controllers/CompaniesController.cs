using EFDapper.Models;
using EFDapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {


        private readonly ICompanyRepository _compRepo;


        public CompaniesController(ICompanyRepository compRepo)
        {
            _compRepo = compRepo;
        }


        [HttpGet("{id}")]
        public Company GeDetails(int id)
        {
            return _compRepo.Find(id);
        }


        [HttpGet]
        public async Task<List<Company>> GetAll()
        {
            return _compRepo.GetAll();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            _compRepo.Add(company);
            return NoContent();
        }


        [HttpPut("{id}")]
        public  async Task<IActionResult> Put(int id, [FromBody] Company company)
        {
            _compRepo.Update(company);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _compRepo.Remove(id);
            return NoContent();
        }


    }
}
