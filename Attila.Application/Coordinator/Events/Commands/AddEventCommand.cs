using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class AddEventCommand : IRequest<int>
    {
        public EventDetailsVM EventDetails { get; set; }

        public class AddEventCommandHandler : IRequestHandler<AddEventCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
            {

                //var _newEvent = new EventDetails
                //{
                //    EventName = request.EventName,
                //    Type = request.Type,
                //    Address = request.Address,
                //    BookingDate = request.BookingDate,
                //    Code = request.Code,
                //    Description = request.Description,
                //    EventClientID = request.EventClientID,
                //    EventDate = request.EventDate,
                //    EventPackageDetailsID = request.EventPackageDetailsID,
                //    Location = request.Location,
                //    Remarks = request.Remarks,
                //    UserID = request.UserID,
                //    EventStatus = Status.Pending

                //};

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
                    VenueType = request.EventDetails.VenueType

                };

                dbContext.Events.Add(_newEvent);
                await dbContext.SaveChangesAsync();

                return _newEvent.ID;

            }
        }
    }
}
