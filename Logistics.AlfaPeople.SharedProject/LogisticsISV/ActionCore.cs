using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Text;

namespace Logistics.AlfaPeople.PluginsDyn1.LogisticsISV
{
	public abstract class ActionCore : CodeActivity
	{
        public IWorkflowContext WorkflowContext { get; set; }
        public IOrganizationServiceFactory ServiceFactory { get; set; }
        public IOrganizationService Service { get; set; }

		protected override void Execute(CodeActivityContext context)
		{
			this.WorkflowContext = context.GetExtension<IWorkflowContext>();
			this.ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
			this.Service = this.ServiceFactory.CreateOrganizationService(this.WorkflowContext.UserId);

			ExecuteAction(context);
		}

		public abstract void ExecuteAction(CodeActivityContext context);
	}
}
