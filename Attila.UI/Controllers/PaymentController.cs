using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attila.UI.Models;
using MediatR;
using Attila.Application.Admin.Event.Queries;
using Attila.Application.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Event.Commands;
using Attila.Application.Coordinator.Event.Commands;
using Attila.Application.Admin.Queries;

namespace Attila.UI.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {

            if (User.Identities != null)
            {
                var _searchResult = await mediator.Send(new GetAllEventDetailsListQuery()); 
             
           


                return View(_searchResult);
            }
            else
            {
                return Redirect("/Login");
            }


        }


        [HttpGet]
        public async Task<IActionResult> FetchRecord(int EventID)
        {

            var eventPackages = await mediator.Send(new GetPaymentStatusByEventIDQuery { EventID = EventID });

            if (eventPackages!=null)
            {
                return View("/Payment/Record", new PaymentVM { Payment = eventPackages });
            }
            else
            {
                return View("/Login");
            }
        }
         
        [Route("Payment/Record")]
        [HttpGet]
        public IActionResult Record(PaymentVM _payment)
        {
            
             
            return View(_payment);

        }



        [HttpGet]
        public IActionResult AddPayment(int EventID)
        {


            var eventID = new EventPaymentVM { 
            
            EventDetailsID = EventID
            
            
            };

            return PartialView("~/Views/Payment/Partials/_AddPayment.cshtml", eventID);


        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentStatusVM _payment)
        {

            bool flag;
            var payment = new PaymentStatusVM {
            Amount  = _payment.Amount,
            EventDetailsID = _payment.EventDetailsID,
            ReferenceNumber = _payment.ReferenceNumber,
            DateOfPayment = DateTime.Now,
            Remarks = _payment.Remarks
            
            
            
            };
                                 

            try
            {
                await mediator.Send(new AddPaymentForEventCommand {

                    MyEventPaymentStatus = payment

                }); flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            return Json(flag);
        }

         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
