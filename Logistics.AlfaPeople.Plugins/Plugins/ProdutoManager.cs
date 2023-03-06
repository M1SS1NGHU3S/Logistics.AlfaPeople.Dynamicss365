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
			Entity product = (Entity)Context.InputParameters["Target"];

			CrmServiceClient serviceClient = Singleton.GetService();
			this.TracingService.Trace("Conexão feita com sucesso");

			GetGrupoUnidadesName(product, out string grupoUnidadeName);
			this.TracingService.Trace("Nome do grupo de unidades recuperado com sucesso");

			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(serviceClient);
			this.TracingService.Trace("Grupo unidades control 2 criado");

			Entity getGrupoByNameReturn = grupoUnidadesControl.GetGrupoByName(grupoUnidadeName);
			this.TracingService.Trace("getGrupoByNameReturn");

			if (getGrupoByNameReturn == null)
			{
				this.TracingService.Trace("Grupo de unidades ainda não criado");
				Guid grupoCreateReturn = grupoUnidadesControl.Create(grupoUnidadeName);
				this.TracingService.Trace(grupoCreateReturn.ToString());
			} else
			{
				this.TracingService.Trace("Grupo de unidades já existente");
			}

		}

		private void GetGrupoUnidadesName(Entity product, out string grupoUnidadeName)
		{
			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.Service);

			EntityReference grupoReference = (EntityReference)product["defaultuomscheduleid"];
			Entity grupoUnidades = grupoUnidadesControl.GetGrupoById(grupoReference.Id);

			grupoUnidadeName = grupoUnidades["name"].ToString();
		}
	}
}
