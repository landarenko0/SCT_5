using Microsoft.Extensions.DependencyInjection;
using SCT_5.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT_5.Factories
{
	public class ServicesFormFactory(IServiceProvider serviceProvider)
	{
		public ServicesForm CreateForm() => ActivatorUtilities.CreateInstance<ServicesForm>(serviceProvider);
	}
}
