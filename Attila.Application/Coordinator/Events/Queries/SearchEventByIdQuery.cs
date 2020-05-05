using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Queries
{
    public class SearchEventByIdQuery : IRequest<EventDetailsVM>
    {
       
        public int EventId { get; set; }
        
        public class SearchEventByIdQueryHandler : IRequestHandler<SearchEventByIdQuery, EventDetailsVM>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;
            public SearchEventByIdQueryHandler(IAttilaDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }


            public async Task<EventDetailsVM> Handle(SearchEventByIdQuery request, CancellationToken cancellationToken)
            {
   
                var _searchedEvent = dbContext.Events
                    .Include(a => a.EventPackage)
                    .Include(a => a.Client)
                    .Where(a => a.ID == request.EventId).SingleOrDefault();


                var _fullEventDetails = new EventDetailsVM
                {
                    ID = _searchedEvent.ID,
                    EventName = _searchedEvent.EventName,
                    Type = _searchedEvent.Type,
                    BookingDate = _searchedEvent.BookingDate,
                    Description = _searchedEvent.Description,
                    EventClientID = _searchedEvent.ClientID,
                    Client = _searchedEvent.Client,
                    EventDate = _searchedEvent.EventDate,
                    PackageDetailsID = _searchedEvent.EventPackageID,
                    Package = _searchedEvent.EventPackage,
                    Location = _searchedEvent.Location,
                    Remarks = _searchedEvent.Remarks,
                    UserID = _searchedEvent.CoordinatorID,
                    EventStatus = _searchedEvent.EventStatus,
                    EntryTime = _searchedEvent.EntryTime,
                    NumberOfGuests = _searchedEvent.NumberOfGuests,
                    ProgramStart = _searchedEvent.ProgramStart,
                    ServingTime = _searchedEvent.ServingTime,
                    LocationType = _searchedEvent.LocationType,
                    ServingType = _searchedEvent.ServingType,
                    Theme = _searchedEvent.Theme,
                    VenueType = _searchedEvent.VenueType,
                    ToPay = _searchedEvent.ToPay,     
                };


                var _additionalEquipmentRequest = await mediator.Send(new FindAdditionalEquipmentRequestByEventIDQuery 
                { 
                    EventID = request.EventId
                });

                if (_additionalEquipmentRequest != null)
                {
                    var _collectionAdditionalEquipment = await mediator.Send(new GetAdditionalEquipmentCollectionQuery
                    {
                        EventAdditionalEquipmentRequestID = _additionalEquipmentRequest.RequestID
                    });

                    _fullEventDetails.AdditionalEquipment = _collectionAdditionalEquipment;
                }
                else
                {
                    _fullEventDetails.AdditionalEquipment = null;
                }



                var _additionalDishRequest = await mediator.Send(new FindAdditionalDishRequestByEventIDQuery 
                { 
                    EventID = request.EventId
                });


                if (_additionalDishRequest != null)
                {
                    var _collectionAdditionalDish = await mediator.Send(new GetAdditionalDishCollectionQuery
                    {
                        EventAdditionalDishRequestID = _additionalDishRequest.RequestID
                    });

                    _fullEventDetails.AdditionalDish = _collectionAdditionalDish;
                }
                else
                {
                    _fullEventDetails.AdditionalDish = null;
                };



                var _collectionAdditionalDuration = await mediator.Send(new GetAdditionalDurationRequestListQuery 
                { 
                    EventID = request.EventId 
                });

                if (_collectionAdditionalDuration.Any())
                {
                    _fullEventDetails.AdditionalDuration = _collectionAdditionalDuration;
                }
                else
                {
                    _fullEventDetails.AdditionalDuration = null;
                }

                var _eventMenu = await mediator.Send(new GetEventMenuQuery 
                { 
                    EventId = request.EventId
                });

                if (_eventMenu.Any())
                {
                    _fullEventDetails.EventMenu = _eventMenu;
                }
               

                return _fullEventDetails;
            }
        }
    }
}
