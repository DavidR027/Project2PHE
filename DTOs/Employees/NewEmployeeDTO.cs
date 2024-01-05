using System;

namespace Project2PHE.DTOs.Employee
{
    public class NewEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }

        public static implicit operator Models.Employee(NewEmployeeDTO employeeDto)
        {
            return new Models.Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                CreateDate = employeeDto.CreateDate,
            };
        }

        public static explicit operator NewEmployeeDTO(Models.Employee employee)
        {
            return new NewEmployeeDTO
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                CreateDate = employee.CreateDate,
            };
        }
    }
}