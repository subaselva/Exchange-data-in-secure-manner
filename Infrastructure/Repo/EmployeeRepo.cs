
using ApplicationLayer.Context;
using ApplicationLayer.DTDs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repo

{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponce> AddAsync(Employee employee)
        {
            var check = await appDbContext.Employees
                .FirstOrDefaultAsync(_ => _.Name.ToLower() == employee.Name.ToLower());
            if(check!= null)
            {
                return new ServiceResponce(false, "User alredy exist");
            }
            await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponce(true, "Added");
        }

        public async Task<ServiceResponce> DeleteAsync(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee == null)
                return new ServiceResponce(false,"User not found");

            appDbContext.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponce(true,"Deleted");
        }

        public async Task<List<Employee>> GetAsync() => await appDbContext.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee> GetByIdAsync(int id) => await appDbContext.Employees.FindAsync(id);

        public async Task<ServiceResponce> UpdateAsync(Employee employee)
        {
            appDbContext.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponce(true, "Updated");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}

