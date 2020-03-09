using HRMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
    }
}
