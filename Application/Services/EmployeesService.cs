using Application.Abstractions;
using Core.Models;
using Core.Repositories;

namespace Application.Services
{
    public class EmployeesService(IEmployeesRepository employeesRepository) : IEmployeesService
    {
        public Task CreateEmployee(Employee employee)
        {
            try
            {
                return employeesRepository.CreateEmployee(employee);
            }
            catch (Exception e)
            {
                // TODO: Добавить проверку для выдачи разных эксепшенов. Например, может отсутствовать подключение к интернету или
                // сотрудник с такими данными уже существует
                throw;
            }
        }

        public Task DeleteEmployee(int employeeId)
        {
            try
            {
                return employeesRepository.DeleteEmployee(employeeId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return employeesRepository.GetAllEmployees();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            try
            {
                // TODO: Заменить обычный эксепшн на что-то вроде NotFoundException
                return await employeesRepository.GetEmployeeById(employeeId) ?? throw new Exception();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task UpdateEmployee(Employee employee)
        {
            try
            {
                return employeesRepository.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
