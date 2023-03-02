using Logistiscs.AlfaPeople.Models.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Controllers
{
	public class ProductController
	{
		public IOrganizationService ServiceClient { get; set; }
		public Product Product { get; set; }

		public ProductController(IOrganizationService serviceClient)
		{
			this.ServiceClient = serviceClient;
			this.Product = new Product(serviceClient);
		}

		public Guid Create(Entity product)
		{
			return Product.Create(product);
		}
	}
}
