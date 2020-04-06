using Attila.Application.Admin.Events.Queries;
using Attila.Application.Coordinator.Events.Commands;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Events.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Attila.UI.Controllers
{
    [Authorize(Roles = "Admin, Coordinator")]
    public class PaymentController : BaseController
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {

            
                var _searchResult = await mediator.Send(new GetAllEventDetailsListQuery()); 
             
           


                return View(_searchResult);
           


        }


        [HttpGet]
        public async Task<IActionResult> Record(int EventID)
        {


            var _searchResult = await mediator.Send(new SearchEventByIdQuery
            {
                EventId = EventID
            });

            var _eventDetails = new EventDetailsVM
            {
                EventName = _searchResult.EventName,
                EventStatus = _searchResult.EventStatus,
                EventDate = _searchResult.EventDate,
                BookingDate = _searchResult.BookingDate,
                Description = _searchResult.Description,
                Remarks = _searchResult.Remarks,
                EntryTime = _searchResult.EntryTime,
                Location = _searchResult.Location,
                LocationType = _searchResult.LocationType,
                NumberOfGuests = _searchResult.NumberOfGuests,
                ProgramStart = _searchResult.ProgramStart,
                PackageDetailsID = _searchResult.PackageDetailsID,
                UserID = _searchResult.UserID,
                EventClientID = _searchResult.EventClientID,
                Theme = _searchResult.Theme,
                ServingType = _searchResult.ServingType,
                ServingTime = _searchResult.ServingTime,
                ID = _searchResult.ID,
                Type = _searchResult.Type,

                VenueType = _searchResult.VenueType,



            };

            var eventPackages = await mediator.Send(new GetPaymentStatusByEventIDQuery { EventID = EventID });
            var eventDetails = new EventPaymentCVM
            {

                PaymentStatus = eventPackages,
                EventDetails = _eventDetails



            };

            return View(eventDetails);
             
        }
         
      


        [HttpGet]
        public async Task<IActionResult> AddPayment(int EventID)
        {


            var _searchResult = await mediator.Send(new SearchEventByIdQuery
            {
                EventId = EventID
            });


            var _eventDetails =  new EventDetailsVM { 
              EventName =_searchResult.EventName,
             EventStatus = _searchResult.EventStatus,
             EventDate =  _searchResult.EventDate,
             BookingDate = _searchResult.BookingDate,
             Description = _searchResult.Description,
             Remarks = _searchResult.Remarks,
             EntryTime = _searchResult.EntryTime,
             Location = _searchResult.Location,
             LocationType = _searchResult.LocationType,
             NumberOfGuests = _searchResult.NumberOfGuests,
                ProgramStart    = _searchResult.ProgramStart,
                PackageDetailsID = _searchResult.PackageDetailsID,
                UserID = _searchResult.UserID,
                EventClientID = _searchResult.EventClientID,
                Theme = _searchResult.Theme,
                ServingType = _searchResult.ServingType,
                ServingTime = _searchResult.ServingTime,
                ID = _searchResult.ID,
                Type =_searchResult.Type,

                VenueType = _searchResult.VenueType,
                
                

            };

           var eventDetails = new EventPaymentCVM { 

            EventDetailsID = EventID,
            EventDetails = _eventDetails



           };

            return View(eventDetails);

        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentStatusVM _payment)
        {
             
            var payment = new PaymentStatusVM {
            Amount  = _payment.Amount,
            EventDetailsID = _payment.EventDetailsID,
            ReferenceNumber = _payment.ReferenceNumber,
            DateOfPayment = DateTime.Now,
            Remarks = _payment.Remarks
            
            
            
            };
                                 

           
             var response =    await mediator.Send(new AddPaymentForEventCommand {

                    MyEventPaymentStatus = payment

                });  
             
            

            return Json(response);
        }

         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
