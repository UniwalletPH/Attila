using Attila.Application.Coordinator.Events.Queries;
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
    public class AddAdditionalDishRequestCommand : IRequest<bool>
    {
        public AdditionalDishVM AdditionalDish { get; set; }
        public class AddAddtitionalDishRequestCommandHandler : IRequestHandler<AddAdditionalDishRequestCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;

            public AddAddtitionalDishRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDishRequestCommand request, CancellationToken cancellationToken)
            {
                var _additionalDish = new EventAdditionalDishRequest
                {
                    EventID = request.AdditionalDish.EventID,
                    Status = Status.Processing

                };

                dbContext.EventAdditionalDishRequests.Add(_additionalDish);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
