using Logistics.AlfaPeople.Models;
using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Logistiscs.AlfaPeople.Models.Controllers;
using Microsoft.Rest;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Linq;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class ProdutoManager : PluginCore
	{
		public Entity Product { get; set; }
		public CrmServiceClient ServiceClient { get; set; }

		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.Product = (Entity)Context.InputParameters["Target"];
			this.ServiceClient = Singleton.GetService();

			Guid grupoUnidadesId = CheckIfGroupExists();
			this.TracingService.Trace(grupoUnidadesId.ToString());
		}

		private Guid CheckIfGroupExists()
		{
			GetGrupoUnidadesName(out string grupoUnidadeName, out string unidadeBaseName);

			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.ServiceClient);
			Entity getGrupoByNameReturn = grupoUnidadesControl.GetGrupoByName(grupoUnidadeName, new string[] { "uomscheduleid" });

			if (getGrupoByNameReturn == null)
			{
				this.TracingService.Trace("Esse grupo de unidades ainda não existe. Criação iniciada.");
				Guid grupoCreateReturn = grupoUnidadesControl.Create(grupoUnidadeName, unidadeBaseName);

				return grupoCreateReturn;
			}
			else
			{
				this.TracingService.Trace("Grupo de unidades já existente");
				return (Guid)getGrupoByNameReturn["uomscheduleid"];
			}
		}

		private void GetGrupoUnidadesName(out string grupoUnidadeName, out string unidadeBaseName)
		{
			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.Service);
			EntityReference grupoReference = (EntityReference)this.Product["defaultuomscheduleid"];
			Entity grupoUnidades = grupoUnidadesControl.GetGrupoById(grupoReference.Id, new string[] { "name", "baseuomname" });

			grupoUnidadeName = grupoUnidades["name"].ToString();
			unidadeBaseName = grupoUnidades["baseuomname"].ToString();
		}
	}
}
