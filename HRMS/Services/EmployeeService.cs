using HRMS.Domain.Model;
using HRMS.Domain.Services;
using HRMS.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        HRMSDbContext _context;

        public EmployeeService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            Employee employeeToUpdate = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if (employeeToUpdate == null)
                throw new ApplicationException("Invalid Employee or Employee doesn't exist.");

            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Email = employee.Email;

            _context.Update(employeeToUpdate);
            await _context.SaveChangesAsync();

            return employeeToUpdate;
        }

    }
}
