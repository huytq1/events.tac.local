using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

using Sitecore.DependencyInjection;
using Sitecore.Mvc.Presentation;

using events.tac.local.Business.Navigation;
using events.tac.local.Controllers;

namespace events.tac.local.Business
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<NavigationModelBuilder>();
            serviceCollection.AddTransient<NavigationController>();
            serviceCollection.AddTransient<RenderingContext>((r) => RenderingContext.Current);
        }
    }
}