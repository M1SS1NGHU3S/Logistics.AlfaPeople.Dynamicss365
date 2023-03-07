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

			//Guid grupoUnidadesId = CheckIfGrupoExists();
			//this.TracingService.Trace(grupoUnidadesId.ToString());

			Guid unidadeId = CheckIfUnidadeExists();
			this.TracingService.Trace(unidadeId.ToString());
		}

		private Guid CheckIfUnidadeExists()
		{
			Entity unidadeInfo = GetUnidadeInfo();
			string unidadeName = unidadeInfo["name"].ToString();

			UnidadeController unidadeControl = new UnidadeController(this.ServiceClient);
			Entity getUnidadeByNameReturn = unidadeControl.GetUnidadeByName(unidadeName, new string[] { "uomid" });

			if (getUnidadeByNameReturn == null)
			{
				return Guid.Empty;
			} 
			else
			{
				this.TracingService.Trace("Unidade já existente");
				return (Guid)getUnidadeByNameReturn["uomid"];
			}
		}

		private Entity GetUnidadeInfo()
		{
			UnidadeController unidadeControl = new UnidadeController(this.Service);
			EntityReference unidadeReference = (EntityReference)this.Product["defaultuomid"];
			Entity unidade = unidadeControl.GetUnidadeById(unidadeReference.Id, new string[]
			{
				"uomscheduleid",
				"name",
				"quantity",
				"baseuom"
			});

			return unidade;
		}

		private Guid CheckIfGrupoExists()
		{
			Entity grupoUnidadesInfo = GetGrupoUnidadesInfo();

			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.ServiceClient);
			Entity getGrupoByNameReturn = grupoUnidadesControl.GetGrupoByName(grupoUnidadesInfo["name"].ToString(), new string[] { "uomscheduleid" });

			if (getGrupoByNameReturn == null)
			{
				this.TracingService.Trace("Esse grupo de unidades ainda não existe. Criação iniciada.");
				Guid grupoCreateReturn = grupoUnidadesControl.Create(grupoUnidadesInfo);

				return grupoCreateReturn;
			}
			else
			{
				this.TracingService.Trace("Grupo de unidades já existente");
				return (Guid)getGrupoByNameReturn["uomscheduleid"];
			}
		}

		private Entity GetGrupoUnidadesInfo()
		{
			GrupoDeUnidadesController grupoUnidadesControl = new GrupoDeUnidadesController(this.Service);
			EntityReference grupoReference = (EntityReference)this.Product["defaultuomscheduleid"];
			Entity grupoUnidades = grupoUnidadesControl.GetGrupoById(grupoReference.Id, new string[] { "name", "baseuomname" });

			return grupoUnidades;
		}
	}
}
