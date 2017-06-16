using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;
using TTAPresentation.TTAOrders.Services;

namespace TTAPresentation.TTAOrders
{
    public class TTAOrdersModuleInitializer : ModuleInitializer
    {
        private const string AuthorizationSection = "compositeWeb/authorization";

        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddModuleServices(container.Services);
            RegisterSiteMapInformation(container.Services.Get<ISiteMapBuilderService>(true));

            container.RegisterTypeMapping<ITTAOrdersController, TTAOrdersController>();
        }

        protected virtual void AddModuleServices(IServiceCollection moduleServices)
        {
            moduleServices.AddNew<OrderDetailsService, IOrderDetailsService>();
            moduleServices.AddNew<OrderListService, IOrderListService>();
            moduleServices.AddNew<OrderSearchService, IOrderSearchService>();
        }

        protected virtual void RegisterSiteMapInformation(ISiteMapBuilderService siteMapBuilderService)
        {
            SiteMapNodeInfo moduleNode = new SiteMapNodeInfo("Orders", "", "Orders");
            siteMapBuilderService.AddNode(moduleNode);
            SiteMapNodeInfo moduleNodeUpdateOrderDetails = new SiteMapNodeInfo("UpdateOrderDetails", "~/TTAOrders/UpdateOrderDetails.aspx", "Update Order Details");
            siteMapBuilderService.AddNode(moduleNodeUpdateOrderDetails, moduleNode);
            SiteMapNodeInfo moduleNodeCreateOrderDetails = new SiteMapNodeInfo("CreateOrderDetails", "~/TTAOrders/CreateOrderDetails.aspx", "Create Order Details");
            siteMapBuilderService.AddNode(moduleNodeCreateOrderDetails, moduleNode);
            SiteMapNodeInfo moduleNodeOrderList = new SiteMapNodeInfo("OrderList", "~/TTAOrders/OrderList.aspx", "Order List");
            siteMapBuilderService.AddNode(moduleNodeOrderList, moduleNode);
            SiteMapNodeInfo moduleNodeOrderSearch = new SiteMapNodeInfo("OrderSearch", "~/TTAOrders/OrderSearch.aspx", "Search Order Details");
            siteMapBuilderService.AddNode(moduleNodeOrderSearch, moduleNode);    
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
