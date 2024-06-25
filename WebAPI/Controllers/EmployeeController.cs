﻿using ApplicationLayer.Context;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }
        [HttpGet]
        
       
        public async Task<ActionResult>Get()
        {
            var data = await employee.GetAsync();
            return Ok(data);

        }
        [HttpGet("{id}")]
       

        public async Task<ActionResult> GetById(int id)
        {
            var data = await employee.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost]
        

        public async Task<IActionResult> Add([FromBody]Employee employeDto)
        {
            var result = await employee.AddAsync(employeDto);
            return Ok(result);

        }
        [HttpPut]
        

        public async Task<IActionResult> Update([FromBody]Employee employeeDto)
        {
            var result = await employee.UpdateAsync(employeeDto);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        
        public async Task<IActionResult>Delete(int id)
        {
            var result = await employee.DeleteAsync(id);
            return Ok(result);

        }
        
    }
}
