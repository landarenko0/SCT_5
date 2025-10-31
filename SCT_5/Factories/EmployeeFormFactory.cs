using Core.Models;
using Microsoft.Extensions.DependencyInjection;
using SCT_5.Forms;

namespace SCT_5.Factories
{
    public class EmployeeFormFactory(IServiceProvider serviceProvider)
    {
        public EmployeeForm CreateForm(Action onSaveButtonClick, Employee? employee = null)
        {
            if (employee is null) return ActivatorUtilities.CreateInstance<EmployeeForm>(serviceProvider, onSaveButtonClick);
            else return ActivatorUtilities.CreateInstance<EmployeeForm>(serviceProvider, employee, onSaveButtonClick);
        }
    }
}
