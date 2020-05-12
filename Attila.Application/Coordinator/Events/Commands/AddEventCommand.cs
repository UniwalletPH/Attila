using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class AddEventCommand : IRequest<EventDetailsVM>
    {
        public EventDetailsVM EventDetails { get; set; }

        public class AddEventCommandHandler : IRequestHandler<AddEventCommand, EventDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventDetailsVM> Handle(AddEventCommand request, CancellationToken cancellationToken)
            {

                var _newEvent = new Event
                {
                    EventName = request.EventDetails.EventName,
                    Type = request.EventDetails.Type,
                    BookingDate = DateTime.Now,
                    Description = request.EventDetails.Description,
                    ClientID = request.EventDetails.EventClientID,
                    EventDate = request.EventDetails.EventDate,
                    EventPackageID = request.EventDetails.PackageDetailsID,
                    Location = request.EventDetails.Location,
                    Remarks = request.EventDetails.Remarks,
                    CoordinatorID = request.EventDetails.UserID,
                    EventStatus = Status.Processing,
                    EntryTime = request.EventDetails.EntryTime,
                    NumberOfGuests = request.EventDetails.NumberOfGuests,
                    ProgramStart = request.EventDetails.ProgramStart,
                    ServingTime = request.EventDetails.ServingTime,
                    LocationType = request.EventDetails.LocationType,
                    ServingType = request.EventDetails.ServingType,
                    Theme = request.EventDetails.Theme,
                    VenueType = request.EventDetails.VenueType,
                    CreatedOn = DateTime.Now
                };

                dbContext.Events.Add(_newEvent);
                await dbContext.SaveChangesAsync();

                return new EventDetailsVM
                { 
                    ID = _newEvent.ID,
                    EventName = _newEvent.EventName,
                    Type = _newEvent.Type,
                    BookingDate = _newEvent.BookingDate,
                    Description = _newEvent.Description,
                    EventClientID = _newEvent.ClientID,
                    EventDate = _newEvent.EventDate,
                    PackageDetailsID = _newEvent.EventPackageID,
                    Location = _newEvent.Location,
                    Remarks = _newEvent.Remarks,
                    UserID = _newEvent.CoordinatorID,
                    EventStatus = _newEvent.EventStatus,
                    EntryTime = _newEvent.EntryTime,
                    NumberOfGuests = _newEvent.NumberOfGuests,
                    ProgramStart = _newEvent.ProgramStart,
                    ServingTime = _newEvent.ServingTime,
                    LocationType = _newEvent.LocationType,
                    ServingType = _newEvent.ServingType,
                    Theme = _newEvent.Theme,
                    VenueType = _newEvent.VenueType                 
                };

            }
        }
    }
}
