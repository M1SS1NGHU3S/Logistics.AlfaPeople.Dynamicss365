﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
	public class GrupoDeUnidades
	{
		public IOrganizationService ServiceClient { get; set; }
		public string LogicalName { get; } = "uomschedule";

		public GrupoDeUnidades(IOrganizationService serviceClient)
		{
			ServiceClient = serviceClient;
		}

		public Guid Create(string grupoName, string unidadeBaseName)
		{
			Entity grupoUnidades = new Entity(this.LogicalName);
			grupoUnidades["name"] = grupoName;
			grupoUnidades["baseuomname"] = unidadeBaseName;

			Guid grupoUnidadesId = ServiceClient.Create(grupoUnidades);
			return grupoUnidadesId;
		}

		public Entity GetGrupoByName(string grupoName, string[] columns)
		{
			QueryExpression queryGrupo = new QueryExpression(this.LogicalName);
			queryGrupo.ColumnSet.AddColumns(columns);
			queryGrupo.Criteria.AddCondition("name", ConditionOperator.Equal, grupoName);

			return RetrieveFirstGrupo(queryGrupo);
		}

		public Entity GetGrupoById(Guid grupoId, string[] columns)
		{
			QueryExpression queryGrupo = new QueryExpression(this.LogicalName);
			queryGrupo.ColumnSet.AddColumns(columns);
			queryGrupo.Criteria.AddCondition("uomscheduleid", ConditionOperator.Equal, grupoId);

			return RetrieveFirstGrupo(queryGrupo);
		}

		public Entity RetrieveFirstGrupo(QueryExpression queryGrupo)
		{
			EntityCollection gruposDeUnidades = this.ServiceClient.RetrieveMultiple(queryGrupo);

			if (gruposDeUnidades.Entities.Count > 0) { return gruposDeUnidades.Entities.FirstOrDefault(); }
			else { return null; }
		}
	}
}
