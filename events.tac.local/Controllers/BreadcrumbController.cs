using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;

using events.tac.local.Models;

namespace events.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private static IEnumerable<NavigationItem> CreateModel()
        {
            var currItem = RenderingContext.Current.ContextItem;
            var homeItem = Context.Database.GetItem(Context.Site.StartPath);
            var breadcrumb = currItem.Axes.GetAncestors()
                .Where(i => i.Axes.IsDescendantOf(homeItem))
                .Concat(new Item[] { currItem })
                .ToList();

            return breadcrumb.Select(n => new NavigationItem()
            {
                Title = n.DisplayName,
                URL = LinkManager.GetItemUrl(n),
                Active = n.ID == currItem.ID
            });
        }
    }
}