using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.Domain.Model;
using HRMS.Domain.Services;
using HRMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await _employeeService.ListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Employee employee)
        {
            var employeeCreated = await _employeeService.AddAsync(employee);

            return Ok(employeeCreated);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Employee employee)
        {
            var employeeUpdated = await _employeeService.UpdateAsync(employee);

            return Ok(employeeUpdated);
        }
    }
}