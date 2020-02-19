using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attila.Application.Coordinator.Event.Commands;
using Attila.Application.Event.Commands;
using Attila.Application.Event.Queries;
using Attila.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Attila.UI.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly IMediator mediator;

        public CoordinatorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        // COORDINATOR COMMANDS START HERE
        #region HTTP POSTs

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventDetailsVM _eventDetails)
        {
            //var _eventDetails = eventDetails;

            await mediator.Send(new AddEventCommand
            {
                Address = _eventDetails.Address,
                BookingDate = _eventDetails.BookingDate,
                Code = _eventDetails.Code,
                Description = _eventDetails.Description,
                EventDate = _eventDetails.EventDate,
                EventName = _eventDetails.EventName,
                EventStatus = _eventDetails.EventStatus,
                Location = _eventDetails.Location,
                Type = _eventDetails.Type,
                Remarks = _eventDetails.Remarks,
                UserID = _eventDetails.UserID,
                EventClientID = _eventDetails.EventClientID,
                EventPackageDetailsID = _eventDetails.EventPackageDetailsID
            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddEventPackage(EventPackageVM _eventPackage)
        {
            await mediator.Send(new AddEventPackageCommand
            {
                Code = _eventPackage.Code,
                Description = _eventPackage.Description,
                Duration = _eventPackage.Duration,
                NumberOfGuest = _eventPackage.NumberOfGuest,
                Rate = _eventPackage.Rate

            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientDetails(EventClientVM _eventClient)
        {
            await mediator.Send(new AddClientDetailsCommand
            {
                Address = _eventClient.Address,
                Contact = _eventClient.Contact,
                Email = _eventClient.Email,
                Lastname = _eventClient.Lastname,
                Firstname = _eventClient.Firstname
            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddEventPayment(EventPaymentVM _eventPayment)
        {
            await mediator.Send(new AddPaymentForEventCommand
            {
                Amount = _eventPayment.Amount,
                DateOfPayment = _eventPayment.DateOfPayment,
                EventDetails = _eventPayment.EventDetails,
                EventDetailsID = _eventPayment.EventDetailsID,
                ReferenceNumber = _eventPayment.ReferenceNumber,
                Remarks = _eventPayment.Remarks

            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> RequestEventRequirements(EventEquipmentRequestVM _eventEquipmentRequest)
        {
            await mediator.Send(new RequestEventRequirementsCommand
            {
                EquipmentDetailsID = _eventEquipmentRequest.EquipmentDetailsID,
                EventDetailsID = _eventEquipmentRequest.EventDetailsID,
                Quantity = _eventEquipmentRequest.Quantity,

            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventDetailsVM _eventDetails)
        {

            await mediator.Send(new UpdateEventCommand
            {
                ID = _eventDetails.ID,
                Address = _eventDetails.Address,
                Description = _eventDetails.Description,
                EventDate = _eventDetails.EventDate,
                EventName = _eventDetails.EventName,
                EventStatus = _eventDetails.EventStatus,
                Location = _eventDetails.Location,
                Type = _eventDetails.Type,
                Remarks = _eventDetails.Remarks

            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEventPackage(EventPackageVM _eventPackage)
        {
            await mediator.Send(new UpdateEventPackageCommand { 
                ID = _eventPackage.ID,
                Code = _eventPackage.Code,
                Description = _eventPackage.Description,
                Duration = _eventPackage.Duration,
                NumberOfGuest = _eventPackage.NumberOfGuest,
                Rate = _eventPackage.Rate
            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClientDetails(EventClientVM _eventClient)
        {
            await mediator.Send(new UpdateClientDetailsCommand { 
                ID = _eventClient.ID,
                Firstname = _eventClient.Firstname,
                Lastname = _eventClient.Lastname,
                Email = _eventClient.Email,
                Address = _eventClient.Address,
                Contact = _eventClient.Contact
            
            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEventPaymentStatus(EventPaymentVM _eventPayment)
        {
            await mediator.Send(new UpdatePaymentStatusCommand { 
                ID = _eventPayment.ID,
                Amount = _eventPayment.Amount,
                DateOfPayment = _eventPayment.DateOfPayment,
                ReferenceNumber = _eventPayment.ReferenceNumber,
                Remarks = _eventPayment.Remarks
            });

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int _eventId)
        {
            await mediator.Send(new DeleteEventCommand { 
                EventId = _eventId

            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEventPackage(int _packageId)
        {
            await mediator.Send(new DeleteEventPackageCommand
            {
                PackageId = _packageId

            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalDurationRequest(PackageAdditionalDurationRequestVM _additionalDuration)
        {
            await mediator.Send(new AddAdditionalDurationRequestCommand { 
                Duration = _additionalDuration.Duration,
                Rate = _additionalDuration.Rate,
                EventDetailsID = _additionalDuration.EventDetailsID
            });
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalEquipmentRequest(PackageAdditionalEquipmentRequestVM _additionalEquipment)
        {
            await mediator.Send(new AddAdditionalEquipmentRequestCommand
            {
                EventDetailsID = _additionalEquipment.EventDetailsID,
                EquipmentDetailsID = _additionalEquipment.EquipmentDetailsID,
                Rate = _additionalEquipment.Rate,
                Quantity = _additionalEquipment.Quantity,
            });
            return Json(true);
        }
        #endregion
        #region HTTP GETs
        [HttpGet]
        public IActionResult AddEvent()
        {
            //var _eventDetails = eventDetails;

            return View();
        }

        [HttpGet]
        public IActionResult AddEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddClientDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEventPayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestEventRequirements()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEvent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateClientDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateEventPaymentStatus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEvent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEventPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAdditionalDurationRequest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAdditionalEquipmentRequest()
        {
            return View();
        }

        #endregion
        //COORDINATOR COMMANDS END HERE



        //COORDINATOR QUERIES START HERE
        #region HTTP POSTs

        [HttpPost]
        public async Task<IActionResult> SearchEventById(int _eventId)
        {
            var _searchResult = await mediator.Send(new SearchEventByIdQuery { 
                EventId = _eventId
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> SearchEventByKeyword(string _eventKeyword)
        {
            var _searchResult = await mediator.Send(new SearchEventByKeywordQuery { 
                EventKeyword = _eventKeyword
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> SearchClientById(int _clientId)
        {
            var _searchResult = await mediator.Send(new SearchClientByIdQuery
            {
                ClientId = _clientId
            });
            return Json(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> SearchClientByKeyword(string _clientKeyword)
        {
            var _searchResult = await mediator.Send(new SearchClientByKeywordQuery { 
                Keyword = _clientKeyword
            });
            return Json(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            var _searchResult = await mediator.Send(new GetEventListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientList()
        {
            var _searchResult = await mediator.Send(new GetEventListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentStatus()
        {
            var _searchResult = await mediator.Send(new GetPaymentStatusQuery());

            return View(_searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> GetPaymentStatusById(int _eventID)
        {
            var _searchResult = await mediator.Send(new GetPaymentStatusByEventIDQuery { 
                EventID = _eventID
            });;

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdditionalDurationRequestList()
        {
            var _searchResult = await mediator.Send(new GetAdditionalDurationRequestListQuery());

            return View(_searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAdditionalEquipmentRequestList()
        {
            var _searchResult = await mediator.Send(new GetAdditionalEquipmentRequestListQuery());

            return View(_searchResult);
        }
        #endregion
        #region HTTP GETs
        //public IActionResult SearchEventById()
        //{
        //    return View();
        //}

        //public IActionResult SearchEventByKeyword()
        //{
        //    return View();
        //}

        //public IActionResult SearchClientById()
        //{
        //    return View();
        //}

        //public IActionResult SearchClientByKeyword()
        //{
        //    return View();
        //}

        //public IActionResult GetEventList()
        //{
        //    return View();
        //}

        //public IActionResult GetClientList()
        //{
        //    return View();
        //}

        //public IActionResult GetPaymentStatus()
        //{
        //    return View();
        //}

        //public IActionResult GetPaymentStatusById()
        //{
        //    return View();
        //}

        //public IActionResult GetAdditionalDurationRequestList()
        //{
        //    return View();
        //}

        //public IActionResult GetAdditionalEquipmentRequestList()
        //{
        //    return View();
        //} 
        #endregion
        //COORDINATOR QUERIES END HERE
    }
}