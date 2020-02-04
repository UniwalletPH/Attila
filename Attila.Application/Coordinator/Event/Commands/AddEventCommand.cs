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
       public EventDetails EventDetails { get; set; }

        public class AddEventCommandHandler : IRequestHandler<AddEventCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
            {

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
                    EventEquipmentsID = request.EventDetails.EventEquipmentsID,
                    EventPackageDetailsID = request.EventDetails.EventPackageDetailsID,
                    EventPaymentStatusID = request.EventDetails.EventPaymentStatusID,
                    EventTeamID =   request.EventDetails.EventTeamID,
                    Location = request.EventDetails.Location,
                    UserID = request.EventDetails.UserID,
                    PackageAdditionalDurationRequestID = request.EventDetails.PackageAdditionalDurationRequestID,
                    PackageAdditionalEquipmentRequestID = request.EventDetails.PackageAdditionalEquipmentRequestID,
                    Remarks = request.EventDetails.Remarks,
                    EventStatus = Status.Pending
                
                };

                dbContext.EventsDetails.Add(_newEvent);
                await dbContext.SaveChangesAsync();

                return request.EventDetails.ID;

            }
        }
    }
}
