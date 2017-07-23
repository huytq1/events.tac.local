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
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            var model = new OverviewList()
            {
                ReadMore = Sitecore.Globalization.Translate.Text("Read More")
            };
            model.AddRange(RenderingContext.Current.ContextItem.GetChildren(Sitecore.Collections.ChildListOptions.SkipSorting)
                .OrderBy(i=>i.Created)
                .Select(i => new OverviewItem()
                {
                    Title = new HtmlString(FieldRenderer.Render(i, "contentheading")),
                    Image = new HtmlString(FieldRenderer.Render(i, "decorationbanner", "mw=500&mh=333")),
                    URL = LinkManager.GetItemUrl(i)
                }));
            return View(model);
        }
    }
}