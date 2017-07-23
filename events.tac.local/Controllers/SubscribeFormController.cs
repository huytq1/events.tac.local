using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore.Analytics;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Outcome.Extensions;
using Sitecore.Analytics.Outcome.Model;

using TAC.Utils.Mvc;

namespace events.tac.local.Controllers
{
    public class SubscribeFormController : Controller
    {
        // GET: SubscribeForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateFormHandler]
        public ActionResult Index(string email)
        {
            //Tracker.Current.Session.Identify(email);
            //var contact = Tracker.Current.Contact;
            //var emails = contact.GetFacet<IContactEmailAddresses>("Emails");
            //if (!emails.Entries.Contains("personal"))
            //{
            //    emails.Preferred = "personal";
            //    var personalEmail = emails.Entries.Create("personal");
            //    personalEmail.SmtpAddress = email;
            //}

            //var outcome = new ContactOutcome(Sitecore.Data.ID.NewID, new Sitecore.Data.ID("{C994A7BA-326F-4C30-B623-AA3EA2D60503}"), contact.ContactId);

            return View("Confirmation");
        }
    }
}