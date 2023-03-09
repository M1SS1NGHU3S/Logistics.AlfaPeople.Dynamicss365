﻿using Logistics.AlfaPeople.Models;
using Logistics.AlfaPeople.PluginsDyn1.LogisticsISV;
using Logistiscs.AlfaPeople.Models.Controllers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AlfaPeople.Plugins.Plugins
{
	public class OportunidadeManager : PluginCore
	{
		public Entity Oportunidade { get; set; }
		public CrmServiceClient ServiceClient { get; set; }

		public override void ExecutePlugin(IServiceProvider serviceProvider)
		{
			this.Oportunidade = (Entity)this.Context.InputParameters["Target"];
			this.ServiceClient = Singleton.GetService();
			this.TracingService.Trace("Serviço recuperado com sucesso");

			Entity oportunidadeToCreate = new Entity("opportunity");
			oportunidadeToCreate["name"] = this.Oportunidade["name"];

			if (this.Oportunidade.Attributes.TryGetValue("purchasetimeframe", out object value))
			{
				oportunidadeToCreate["purchasetimeframe"] = value;
			}
			else
			{
				this.TracingService.Trace("purchasetimeframe não definido");
			}

			OportunidadeController oportunidadeControl = new OportunidadeController(this.ServiceClient);
			oportunidadeControl.Create(oportunidadeToCreate);
			this.TracingService.Trace("Oportunidade nova criada");
		}
	}
}
