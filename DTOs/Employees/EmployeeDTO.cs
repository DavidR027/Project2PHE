using System;
using System.ComponentModel.DataAnnotations;

namespace Project2PHE.DTOs.Employee
{
    public class EmployeeDTO
    {
        [Key]
        public string Guid { get; set; } = null;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public static implicit operator Models.Employee(EmployeeDTO employeeDto)
        {
            return new Models.Employee
            {
                Guid = employeeDto.Guid,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                CreateDate = employeeDto.CreateDate,
                IsDeleted = employeeDto.IsDeleted,
            };
        }

        public static explicit operator EmployeeDTO(Models.Employee employee)
        {
            return new EmployeeDTO
            {
                Guid = employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                CreateDate = employee.CreateDate,
                IsDeleted = employee.IsDeleted,
            };
        }
    }
}