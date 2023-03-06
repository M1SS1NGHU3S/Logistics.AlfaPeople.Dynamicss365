using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class UnidadeController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Unidade Unidade { get; set; }

		public UnidadeController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Unidade = new Unidade(this.ServiceClient);
		}
	}
}
