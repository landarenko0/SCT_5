using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.ViewModels
{
    public class EmployeesViewModel
    {
        private readonly IEmployeesRepository _employeesRepository;

        private readonly ILogger _logger;

        private List<Employee> _employees = [];

        public event Action<List<Employee>>? OnEmployeesChanged = null;

        public event Action<string>? OnError = null;

        public event Action<bool>? UpdateButtonsState = null;

        public event Action? ClearEmployeesTable = null;

        public EmployeesViewModel(IEmployeesRepository employeesRepository, ILogger<EmployeesViewModel> logger)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;

            Task.Run(async () =>
            {
                await UpdateEmployeesList();

                OnEmployeesChanged?.Invoke(_employees);
                UpdateButtonsState?.Invoke(_employees.Count > 0);
            });
        }

        public void OnDeleteEmployeeConfirmed(int selectedIndex)
        {
            UpdateButtonsState?.Invoke(false);
            ClearEmployeesTable?.Invoke();

            Task.Run(async () =>
            {
                Employee employee = _employees[selectedIndex];

                await DeleteEmployee(employee);
                await UpdateEmployeesList();

                OnEmployeesChanged?.Invoke(_employees);
                UpdateButtonsState?.Invoke(_employees.Count > 0);
            });
        }

        private async Task DeleteEmployee(Employee employee)
        {
            try
            {
                await _employeesRepository.DeleteEmployee(employee.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while DeleteEmployee() was executing");
                OnError?.Invoke("Произошла ошибка");
            }
        }

        private async Task UpdateEmployeesList()
        {
            try
            {
                _employees = await _employeesRepository.GetAllEmployees();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while UpdateEmployeesList() was executing");
                OnError?.Invoke("Произошла ошибка");
            }
        }

        public void OnEmployeeFormSaveButtonClicked()
        {
            ClearEmployeesTable?.Invoke();
            UpdateButtonsState?.Invoke(false);

            Task.Run(async () =>
            {
                await UpdateEmployeesList();

                OnEmployeesChanged?.Invoke(_employees);
                UpdateButtonsState?.Invoke(_employees.Count > 0);
            });
        }

        public Employee? GetSelectedEmployee(int selectedIndex)
        {
            return selectedIndex >= 0 && selectedIndex < _employees.Count ? _employees[selectedIndex] : null;
        }
    }
}
