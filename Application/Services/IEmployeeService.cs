using ApplicationLayer.DTDs;
using DomainLayer.Entities;


namespace ApplicationLayer.Services
{
    public  interface IEmployeeService
    {
        Task<ServiceResponce> AddAsync(Employee employee);
        Task<ServiceResponce> UpdateAsync(Employee employee);

        Task<ServiceResponce> DeleteAsync(int id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
