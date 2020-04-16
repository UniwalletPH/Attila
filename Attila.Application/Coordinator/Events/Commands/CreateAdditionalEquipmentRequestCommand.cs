using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class CreateAdditionalEquipmentRequestCommand : IRequest<int>
    {
        public int EventID { get; set; }
        public class CreateAdditionalEquipmentRequestCommandHandler : IRequestHandler<CreateAdditionalEquipmentRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public CreateAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(CreateAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                var _newAddEquipmentRequest = new EventAdditionalEquipmentRequest
                { 
                    EventID = request.EventID,
                    CreatedOn = DateTime.Now,
                    Status = Status.Processing
                };

                 dbContext.EventAdditionalEquipmentRequests.Add(_newAddEquipmentRequest);
                await dbContext.SaveChangesAsync();

                return _newAddEquipmentRequest.ID;
            }
        }

    }
}
