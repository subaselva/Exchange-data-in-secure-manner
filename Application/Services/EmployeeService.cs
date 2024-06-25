

using ApplicationLayer.Context;
using ApplicationLayer.DTDs;
using DomainLayer.Entities;
using System.Net.Http.Json;

namespace ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponce> AddAsync(Employee employee)
        {
            var data = await httpClient.PostAsJsonAsync("api/employee",employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponce>();
            return response!;
        }

        public async Task<ServiceResponce> DeleteAsync(int id)
        {
            var data = await httpClient.DeleteAsync($"api/employee/{id}");
            var reponse = await data.Content.ReadFromJsonAsync<ServiceResponce>();
            return reponse!; ;
        }

        public async Task<List<Employee>> GetAsync() =>
            await httpClient.GetFromJsonAsync<List<Employee>>("api/employee");
        

        public async Task<Employee> GetByIdAsync(int id)=>
            await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}")!;


        public async Task<ServiceResponce> UpdateAsync(Employee employee)
        {
            var data = await httpClient.PutAsJsonAsync("api/employee", employee);
            var reponse = await data.Content.ReadFromJsonAsync<ServiceResponce>();
            return reponse!;
        }
    }
}
