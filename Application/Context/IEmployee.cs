


using ApplicationLayer.DTDs;
using DomainLayer.Entities;

namespace ApplicationLayer.Context
{
    public interface IEmployee
    {
        Task<ServiceResponce> AddAsync(Employee employee);
        Task<ServiceResponce> UpdateAsync(Employee employee);

        Task<ServiceResponce> DeleteAsync(int id);
        Task<List<Employee> >GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
