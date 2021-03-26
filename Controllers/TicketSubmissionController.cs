using Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Library;
using static Data_Library.Business_Logic.TicketProcessor;
using Data_Library.Models;


namespace Bug_Tracker.Controllers
{
    public class TicketSubmissionController : Controller
    {
        // GET: TicketSubmission
        public ActionResult TicketSubmission()
        {
           var Projects = ListProjects();
           ViewBag.ProjectsList = new SelectList(Projects);

            var PriorityList = ListPriority();
           ViewBag.PriorityList = new SelectList(PriorityList);

           var TypeList = ListType();
           ViewBag.TypeList = new SelectList(TypeList);

           return View();
        }

        // Send: TicketSubmission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TicketSubmission(Ticket model)
        {
            if (ModelState.IsValid)
            {
                //Create or update submitter information
                SubmitterInfo(model.SubmitterName,
                              model.SubmitterEmail);

                //Create ticket in DB
                CreateTicket(model.TicketName, 
                             model.TicketDescription,
                             model.CreatedDate);

                //Add relational DB info to table
                TicketIDValues(model.SubmitterEmail,
                               model.TicketType,
                               model.Priority,
                               model.TicketName,
                               model.ProjectName);

                return RedirectToAction("Index" , "TicketDetails");
            }

            return View();
        }

        public ActionResult ViewTickets()
        {
            ViewBag.Message = "Tickets List";

            var data = LoadTickets();
            List<Ticket> Tickets = new List<Ticket>();

            foreach (var row in data)
            {
                Tickets.Add(new Ticket
                {
                    TicketName = row.TicketName,
                    TicketDescription = row.TicketDescription,
                    CreatedDate  = row.CreatedDate
                });
            }

            return View(Tickets);

        }
    }
}