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
    public class AddEventDishRequestCommand : IRequest<bool>
    {
        public List<EventDishRequestVM> EventDishRequest { get; set; }
        public class AddEventDishRequestCommandHandler : IRequestHandler<AddEventDishRequestCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;

            public AddEventDishRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventDishRequestCommand request, CancellationToken cancellationToken)
            {
                foreach (var item in request.EventDishRequest)
                {
                    var EventDishRequests = new EventDishRequestCollection
                    {
                        AdditionalDishID = item.AdditionalDishID,
                        DishID = item.DishID
                    };
                    dbContext.EventDishRequests.Add(EventDishRequests);
                    await dbContext.SaveChangesAsync();
                }
                return true;
            }
        }
    }
}
