using Microsoft.Extensions.DependencyInjection;
using SCT_5.Forms;

namespace SCT_5.Factories
{
    public class EmployeesFormFactory(IServiceProvider serviceProvider)
    {
        public EmployeesForm CreateForm() => ActivatorUtilities.CreateInstance<EmployeesForm>(serviceProvider);
    }
}
