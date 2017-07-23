using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore.Web.UI.WebControls;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;

using events.tac.local.Models;

namespace events.tac.local.Controllers
{
    public class FeaturedEventController : Controller
    {
        // GET: FeaturedEvent
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private static FeaturedEvent CreateModel()
        {
            var item = RenderingContext.Current.Rendering.Item;
            var featuredEvent = new FeaturedEvent()
            {
                Heading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                Intro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "Event Image", "mw=400")),
                URL = LinkManager.GetItemUrl(item)
            };
            var cssClass = RenderingContext.Current.Rendering.Parameters["CssClass"];
            if (!string.IsNullOrEmpty(cssClass))
            {
                var refItem = Sitecore.Context.Database.GetItem(cssClass);
                if (refItem!=null)
                {
                    featuredEvent.CssClass = refItem["class"];
                }
                else
                {
                    featuredEvent.CssClass = cssClass;
                }
            }
            return featuredEvent;
        }
    }
}