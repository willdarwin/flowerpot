using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;
using TTAPresentation.TTAProduct.Services;

namespace TTAPresentation.TTAProduct
{
    public class TTAProductModuleInitializer : ModuleInitializer
    {
        private const string AuthorizationSection = "compositeWeb/authorization";

        /// <summary>
        /// Loads the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddModuleServices(container.Services);
            RegisterSiteMapInformation(container.Services.Get<ISiteMapBuilderService>(true));

            container.RegisterTypeMapping<ITTAProductController, TTAProductController>();
        }

        protected virtual void AddModuleServices(IServiceCollection moduleServices)
        {
            moduleServices.AddNew<ProductService, IProductService>();
        }

        protected virtual void RegisterSiteMapInformation(ISiteMapBuilderService siteMapBuilderService)
        {
            SiteMapNodeInfo moduleNode = new SiteMapNodeInfo("Products", "~/TTAProduct/ProductList.aspx", "Products");
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
