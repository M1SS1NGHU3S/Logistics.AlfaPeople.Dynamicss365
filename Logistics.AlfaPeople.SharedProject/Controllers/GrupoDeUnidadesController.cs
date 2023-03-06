using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class GrupoDeUnidadesController
	{
		public IOrganizationService ServiceClient { get; set; }
		public GrupoDeUnidades GrupoUnidades { get; set; }

		public GrupoDeUnidadesController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.GrupoUnidades = new GrupoDeUnidades(this.ServiceClient);
		}

		public Entity GetGrupoByName(string grupoName)
		{
			return GrupoUnidades.GetGrupoByName(grupoName, new string[] { "uomscheduleid" });
		}

		public Entity GetGrupoById(Guid grupoId)
		{
			return GrupoUnidades.GetGrupoById(grupoId, new string[] { "name" });
		}
	}
}
