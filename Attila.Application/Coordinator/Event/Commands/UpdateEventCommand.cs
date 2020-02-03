using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Event.Commands
{
    public class UpdateEventCommand : IRequest<bool>
    {
        private readonly EventDetails details;
        public UpdateEventCommand(EventDetails details)
        {
            this.details = details;
        }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public UpdateEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var _updatedEventDetails = dbContext.EventsDetails.Find(request.details.ID);

                _updatedEventDetails.Address = request.details.Address;
                _updatedEventDetails.Description = request.details.Description;
                _updatedEventDetails.EventDate = request.details.EventDate;
                _updatedEventDetails.EventName = request.details.EventName;
                _updatedEventDetails.EventStatus = request.details.EventStatus;
                _updatedEventDetails.Location = request.details.Location;
                _updatedEventDetails.Type = request.details.Type;
                _updatedEventDetails.Remarks = request.details.Remarks;
                

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
