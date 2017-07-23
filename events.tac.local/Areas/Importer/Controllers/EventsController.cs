using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.SecurityModel;
using Sitecore.Data.Items;

using Newtonsoft.Json;

using events.tac.local.Areas.Importer.Models;

namespace events.tac.local.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {
            IEnumerable<Event> events = null;
            //string message = null;

            // parse json
            using (var reader= new System.IO.StreamReader(file.InputStream))
            {
                var content = reader.ReadToEnd();
                try
                {
                    events = JsonConvert.DeserializeObject<IEnumerable<Event>>(content);
                }
                catch (Exception)
                {
                }
            }

            // create content items
            var master = Factory.GetDatabase("master");
            var parentItem = master.GetItem(parentPath);
            var templateID = new TemplateID(new ID("{884674D4-3556-47F0-92F1-EEDFA2D67BFA}"));
            ViewBag.events = new List<string>();
            using (new SecurityDisabler())
            {
                foreach (var ev in events)
                {
                    try
                    {
                        var name = ItemUtil.ProposeValidItemName(ev.ContentHeading);
                        var item = parentItem.Add(name, templateID);
                        item.Editing.BeginEdit();
                        item["ContentHeading"] = ev.ContentHeading;
                        item["ContentIntro"] = ev.ContentIntro;
                        item["Highlights"] = ev.Highlights;
                        item["StartDate"] = ev.StartDate.ToString();
                        item["Duration"] = ev.Duration.ToString();
                        item["Difficulty"] = ev.Difficulty.ToString();
                        item.Editing.EndEdit();

                        ViewBag.events.Add(ev.ContentHeading);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return View("Result");
        }
    }
}