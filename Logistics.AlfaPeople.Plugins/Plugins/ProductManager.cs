using Logistics.AlfaPeople.Models;
using Logistics.AlfaPeople.Plugins.LogisticsISV;
using Logistiscs.AlfaPeople.Models.Controllers;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class ProductManager : PluginCore
	{
		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.TracingService.Trace("Entrou no Plugin");

			Entity product = (Entity)Context.InputParameters["Target"];
			this.TracingService.Trace("Pegou o produto");

			ProductController productController = new ProductController(Connector.GetService());
			this.TracingService.Trace(productController.Create(product).ToString());
		}
	}
}
