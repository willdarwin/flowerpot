using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;
using TTAPresentation.TTACustomer.Services;

namespace TTAPresentation.TTACustomer
{
    public class TTACustomerModuleInitializer : ModuleInitializer
    {
        private const string AuthorizationSection = "compositeWeb/authorization";

        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddModuleServices(container.Services);
            RegisterSiteMapInformation(container.Services.Get<ISiteMapBuilderService>(true));

            container.RegisterTypeMapping<ITTACustomerController, TTACustomerController>();
        }

        protected virtual void AddModuleServices(IServiceCollection moduleServices)
        {
            moduleServices.AddNew<CustomerService, ICustomerService>();
        }

        protected virtual void RegisterSiteMapInformation(ISiteMapBuilderService siteMapBuilderService)
        {
            SiteMapNodeInfo moduleNode = new SiteMapNodeInfo("Customers", "~/TTACustomer/ShowAllCustomers.aspx", "Customers");
            siteMapBuilderService.AddNode(moduleNode); 
        }

        public override void Configure(IServiceCollection services, System.Configuration.Configuration moduleConfiguration)
        {
            IAuthorizationRulesService authorizationRuleService = services.Get<IAuthorizationRulesService>();
            if (authorizationRuleService != null)
            {
                AuthorizationConfigurationSection authorizationSection = moduleConfiguration.GetSection(AuthorizationSection) as AuthorizationConfigurationSection;
                if (authorizationSection != null)
                {
                    foreach (AuthorizationRuleElement ruleElement in authorizationSection.ModuleRules)
                    {
                        authorizationRuleService.RegisterAuthorizationRule(ruleElement.AbsolutePath, ruleElement.RuleName);
                    }
                }
            }
        }
    }
}
