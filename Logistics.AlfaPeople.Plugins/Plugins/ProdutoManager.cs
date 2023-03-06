using Logistics.AlfaPeople.Models;
using Logistics.AlfaPeople.Plugins.LogisticsISV;
using Logistiscs.AlfaPeople.Models.Controllers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Linq;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class ProdutoManager : PluginCore
	{
		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.TracingService.Trace("Entrou no Plugin");

			Entity product = (Entity)Context.InputParameters["Target"];
			this.TracingService.Trace("Pegou o produto");

			CrmServiceClient serviceClient = Singleton.GetService();
			this.TracingService.Trace("Conexão feita com sucesso");

			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.Service);

			EntityReference grupoReference = (EntityReference)product["defaultuomscheduleid"];
			Entity grupoUnidades = grupoUnidadesControl.GetGrupoById(grupoReference.Id);

			this.TracingService.Trace(grupoUnidades["name"].ToString());
		}
	}
}
