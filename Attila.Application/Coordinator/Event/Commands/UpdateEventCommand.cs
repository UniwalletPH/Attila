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
        //public EventDetails UpdateEvent { get; set; }
        public int ID { get; set; }

        public string Code { get; set; }

        public string EventName { get; set; }

        public EventType Type { get; set; }

        public Status EventStatus { get; set; }

        public string Address { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int EventPackageDetailsID { get; set; }

        public int EventClientID { get; set; }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventDetails = dbContext.EventsDetails.Find(request.ID);

                _updatedEventDetails.Address = request.Address;
                _updatedEventDetails.Description = request.Description;
                _updatedEventDetails.EventDate = request.EventDate;
                _updatedEventDetails.EventName = request.EventName;
                _updatedEventDetails.EventStatus = request.EventStatus;
                _updatedEventDetails.Location = request.Location;
                _updatedEventDetails.Type = request.Type;
                _updatedEventDetails.Remarks = request.Remarks;
                

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
