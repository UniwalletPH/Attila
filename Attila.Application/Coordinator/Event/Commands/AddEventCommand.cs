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

                var _newEvent = new EventDetails
                {
                    EventName = request.EventDetails.EventName,
                    Type = request.EventDetails.Type,
                    Address = request.EventDetails.Address,
                    BookingDate = request.EventDetails.BookingDate,
                    Code = request.EventDetails.Code,
                    Description = request.EventDetails.Description,
                    EventClientID = request.EventDetails.EventClientID,
                    EventDate = request.EventDetails.EventDate,
                    EventPackageDetailsID = request.EventDetails.EventPackageDetailsID,
                    Location = request.EventDetails.Location,
                    Remarks = request.EventDetails.Remarks,
                    UserID = request.EventDetails.UserID,
                    EventStatus = Status.Pending

                };

                dbContext.EventsDetails.Add(_newEvent);
                await dbContext.SaveChangesAsync();

                return request.EventDetails.ID;

            }
        }
    }
}
