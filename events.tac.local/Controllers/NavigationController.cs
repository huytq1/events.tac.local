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

using TAC.Utils.SitecoreModels;

using events.tac.local.Models;
using events.tac.local.Business.Navigation;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationModelBuilder _modelBuilder;
        private readonly RenderingContext _context;

        public NavigationController(NavigationModelBuilder modelBuilder, RenderingContext context)
        {
            _modelBuilder = modelBuilder;
            _context = context;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            var currItem = _context.ContextItem;
            var section = currItem.Axes.GetAncestors()
                .FirstOrDefault(i => i.TemplateName == "Events Section");            
            return View(_modelBuilder.CreateNavigationMenu(section, currItem));
        }        
    }
}