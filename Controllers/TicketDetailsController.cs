using Data_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static Data_Library.Business_Logic.TicketProcessor;

namespace Bug_Tracker.Controllers
{
    public class TicketDetailsController : Controller
    {
        // GET: TicketDetails
        public ActionResult Index()
        {
            ViewBag.Message = "Ticket Details";

            var data = LoadTickets();
            List<TicketModel> Tickets = new List<TicketModel>();

            foreach (var row in data)
            {
                Tickets.Add(new TicketModel
                {
                    TicketID = row.TicketID,
                    TicketName = row.TicketName,
                    TicketDescription = row.TicketDescription,
                    ProjectName = row.ProjectName,
                    Priority = row.Priority,
                    PriorityDescription = row.PriorityDescription,
                    TicketType = row.TicketType,
                    SubmitterName = row.SubmitterName,
                    SubmitterEmail = row.SubmitterEmail,
                    CreatedDate = row.CreatedDate,
                    UpdatedLast = row.UpdatedLast
                });
            }

            return View(Tickets);
        }

        // GET: Edit Ticket Details
        public ActionResult Edit() 
        {
            return View();
        }


        // GET: Edit Ticket
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Edit";
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = LoadTicket(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            List<TicketModel> Ticket = new List<TicketModel>();
            foreach (var row in data)
            {
                Ticket.Add(new TicketModel
                {
                    TicketID = row.TicketID,
                    TicketName = row.TicketName,
                    TicketDescription = row.TicketDescription,
                    ProjectName = row.ProjectName,
                    Priority = row.Priority,
                    PriorityDescription = row.PriorityDescription,
                    TicketType = row.TicketType,
                    SubmitterName = row.SubmitterName,
                    SubmitterEmail = row.SubmitterEmail,
                    CreatedDate = row.CreatedDate,
                    UpdatedLast = row.UpdatedLast
                });
            }

            return View(Ticket);
        }

    }
}