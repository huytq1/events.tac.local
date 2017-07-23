using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;

using TAC.Utils.Abstractions;
using TAC.Utils.SitecoreModels;

using events.tac.local.Models;

namespace events.tac.local.Business.Navigation
{
    public class NavigationModelBuilder
    {
        public NavigationMenu CreateNavigationMenu(Item root, Item current)
        {
            return new NavigationMenu()
            {
                Title = root.DisplayName,
                URL = LinkManager.GetItemUrl(root),
                Children = root.Axes.IsAncestorOf(current) ? root.GetChildren().Select(i => CreateNavigationMenu(i, current)) : null
            };
        }
    }
}