using EFDapper.Models;

namespace EFDapper.Repository
{
    public interface IBonusRepository
    {
        List<Employee> GetEmployeeWithCompany(int id);

        Company GetCompanyWithEmployees(int id);

        List<Company> GetAllCompanyWithEmployees();

        //Bulk insert with Dapper
        void AddTestCompanyWithEmployees(Company objComp);

        void AddTestCompanyWithEmployeesWithTransaction(Company objComp);

        void RemoveRange(int[] companyId);

        List<Company> FilterCompanyByName(string name);
    }
}
