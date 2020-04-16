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
    public class AddAdditionalDishRequestCollectionCommand : IRequest<bool>
    {
        public EventDishRequestVM Dish { get; set; }

        public class AddAdditionalDishRequestCollectionCommandHandler : IRequestHandler<AddAdditionalDishRequestCollectionCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddAdditionalDishRequestCollectionCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalDishRequestCollectionCommand request, CancellationToken cancellationToken)
            {
                var _newDishRequest = new EventDishRequestCollection
                { 
                    DishID = request.Dish.DishID,
                    CreatedOn = DateTime.Now,
                    AdditionalDishID = request.Dish.RequestID,
                    Quantity = request.Dish.Quantity
                    
                };

                dbContext.EventDishRequestCollection.Add(_newDishRequest);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
