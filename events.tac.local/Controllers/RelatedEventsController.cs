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
using Sitecore.Data.Fields;

using events.tac.local.Models;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            var item = RenderingContext.Current.Rendering.Item;
            if (item == null) return new EmptyResult();

            MultilistField related = item.Fields["Related Events"];
            if (related == null) return new EmptyResult();

            var events = related.GetItems()
                .Select(i => new NavigationItem()
                {
                    Title = i.DisplayName,
                    URL = LinkManager.GetItemUrl(i)
                });

            return View(events);
        }
    }
}