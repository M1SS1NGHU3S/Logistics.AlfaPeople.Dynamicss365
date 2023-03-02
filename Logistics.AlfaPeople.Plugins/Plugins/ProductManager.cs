using Logistics.AlfaPeople.Plugins.LogisticsISV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class ProductManager : PluginCore
	{
		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.TracingService.Trace("Entrou no Plugin");
		}
	}
}
