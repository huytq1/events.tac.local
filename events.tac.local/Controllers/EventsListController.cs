using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;

using events.tac.local.Models;

namespace events.tac.local.Controllers
{
    public class EventsListController : Controller
    {
        private const int PageSize = 4;
        // GET: EventsList
        public ActionResult Index(int page=1)
        {
            var item = RenderingContext.Current.ContextItem;
            var model = new EventsList();
            var dbName = item.Database.Name.ToLower();
            var indexName = $"events_{dbName}_index";
            var index = ContentSearchManager.GetIndex(indexName);
            using (var context=index.CreateSearchContext())
            {
                var result = context.GetQueryable<EventDetails>()
                    .Where(e => e.Paths.Contains(item.ID) && e.Language == item.Language.Name)
                    .Page(page - 1, PageSize)
                    .GetResults();
                model.Events = result.Hits.Select(h => h.Document).ToList();
                model.TotalResultCount = result.TotalSearchResults;
                model.PageSize = PageSize;
            }

            return View(model);
        }
    }
}