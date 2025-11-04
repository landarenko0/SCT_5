using Core.Models;
using Microsoft.Extensions.DependencyInjection;
using SCT_5.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT_5.Factories
{
	public class ServiceFormFactory(IServiceProvider serviceProvider)
	{
		public ServiceForm CreateForm(Action onSaveButtonClick, Service? service = null)
		{
			if (service is null) return ActivatorUtilities.CreateInstance<ServiceForm>(serviceProvider, onSaveButtonClick);
			else return ActivatorUtilities.CreateInstance<ServiceForm>(serviceProvider, service, onSaveButtonClick);
		}
	}

}
