using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
	public class Product
	{
		public IOrganizationService ServiceClient { get; set; }
		public string LogicalName { get; set; } = "product";

		public Product(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
		}

		public Guid Create(Entity product)
		{
			Guid productId = ServiceClient.Create(product);
			return productId;
		}
	}
}
