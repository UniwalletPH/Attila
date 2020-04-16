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
    public class CreateAdditionalDishRequestCommand : IRequest<int>
    {
        public int EventID { get; set; }
        public class CreateAdditionalDishRequestCommandHandler : IRequestHandler<CreateAdditionalDishRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public CreateAdditionalDishRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(CreateAdditionalDishRequestCommand request, CancellationToken cancellationToken)
            {
                var _newDishRequest = new EventAdditionalDishRequest
                { 
                    EventID = request.EventID,
                    CreatedOn = DateTime.Now,
                    Status = Status.Processing
                };

                dbContext.EventAdditionalDishRequests.Add(_newDishRequest);
                await dbContext.SaveChangesAsync();

                return _newDishRequest.ID;
            }
        }
    }
}
