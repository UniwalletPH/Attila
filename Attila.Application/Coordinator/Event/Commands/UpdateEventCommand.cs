using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Commands
{
    public class UpdateEventCommand : IRequest<bool>
    {
        public EventDetailsVM UpdateEvent { get; set; }
        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventDetails = dbContext.EventDetails.Find(request.UpdateEvent.ID);
                _updatedEventDetails.EventName = request.UpdateEvent.EventName;
                _updatedEventDetails.Type = request.UpdateEvent.Type;
                _updatedEventDetails.BookingDate = request.UpdateEvent.BookingDate;
                _updatedEventDetails.Theme = request.UpdateEvent.Theme;
                _updatedEventDetails.Description = request.UpdateEvent.Description;
                _updatedEventDetails.EventClientID = request.UpdateEvent.EventClientID;
                _updatedEventDetails.EventDate = request.UpdateEvent.EventDate;
                _updatedEventDetails.PackageDetailsID = request.UpdateEvent.PackageDetailsID;
                _updatedEventDetails.Location = request.UpdateEvent.Location;
                _updatedEventDetails.Remarks = request.UpdateEvent.Remarks;
                _updatedEventDetails.UserID = request.UpdateEvent.UserID;
                _updatedEventDetails.EventStatus = Status.Pending;
                _updatedEventDetails.EntryTime = request.UpdateEvent.EntryTime;
                _updatedEventDetails.NumberOfGuests = request.UpdateEvent.NumberOfGuests;
                _updatedEventDetails.ProgramStart = request.UpdateEvent.ProgramStart;
                _updatedEventDetails.ServingTime = request.UpdateEvent.ServingTime;
                _updatedEventDetails.ServingType = request.UpdateEvent.ServingType;
                

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
