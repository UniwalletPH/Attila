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
                var _updatedEventDetails = dbContext.EventsDetails.Find(request.UpdateEvent.ID);
                _updatedEventDetails.Description = request.UpdateEvent.Description;
                _updatedEventDetails.EventDate = request.UpdateEvent.EventDate;
                _updatedEventDetails.EventName = request.UpdateEvent.EventName;
                _updatedEventDetails.EventStatus = request.UpdateEvent.EventStatus;
                _updatedEventDetails.Location = request.UpdateEvent.Location;
                _updatedEventDetails.Type = request.UpdateEvent.Type;
                _updatedEventDetails.Remarks = request.UpdateEvent.Remarks;
                

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
