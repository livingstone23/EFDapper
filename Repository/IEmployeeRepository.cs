using EFDapper.Models;

namespace EFDapper.Repository
{
    public interface IEmployeeRepository
    {

        Employee Find(int id);
        List<Employee> GetAll();
        Employee Add(Employee employee);

        //Async with dapper
        Task<Employee> AddAsync(Employee employee);
        Employee Update(Employee employee);
        void Remove(int id);

    }
}
