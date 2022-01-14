﻿using Dapper;
using EFDapper.Data;
using EFDapper.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EFDapper.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IDbConnection db;

        public CompanyRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Company Add(Company company)
        {
            var sql = "Insert into Companies(Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @Statem @PostalCode)"
                        + " Select Cast(SCOPE_IDENTITY() as int); ";
            var id = db.Query<int>(sql, new
            {
                company.Name,
                company.Address,
                company.City,
                company.State,
                company.PostalCode
            }).Single();
            company.CompanyId = id;
            return company;
        }

        public Company Find(int id)
        {
            var sql = "Select * from Companies Where CompanyId = @Id";
            return db.Query<Company>(sql, new { @CompanyId = id }).Single();

        }

        public List<Company> GetAll()
        {
            var sql = "Select * from Companies";
            return db.Query<Company>(sql).ToList();
        }

        public void Remove(int id)
        {
            
        }

        public Company Update(Company company)
        {
            return null;
        }
    }


}
