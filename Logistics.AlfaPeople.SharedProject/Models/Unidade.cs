using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
	public class Unidade
	{
		public IOrganizationService ServiceClient { get; set; }
		public string LogicalName { get; } = "uom";

		public Unidade(IOrganizationService serviceClient)
		{
			ServiceClient = serviceClient;
		}
	}
}
