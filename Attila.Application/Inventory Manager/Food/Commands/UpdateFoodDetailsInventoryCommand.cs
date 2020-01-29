using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class UpdateFoodDetailsInventoryCommand : IRequest<bool>
    {
        private readonly FoodDetails myFoodDetails;
        public UpdateFoodDetailsInventoryCommand(FoodDetails myFoodDetails)
        {
            this.myFoodDetails = myFoodDetails;
        }

        public class UpdateFoodDetailsInventoryCommandHandler : IRequestHandler<UpdateFoodDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodDetails = dbContext.FoodsDetails.Find(request.myFoodDetails.ID);

                _updatedFoodDetails.Code = request.myFoodDetails.Code;
                _updatedFoodDetails.Name = request.myFoodDetails.Name;
                _updatedFoodDetails.Specification = request.myFoodDetails.Specification;
                _updatedFoodDetails.Description = request.myFoodDetails.Description;
                _updatedFoodDetails.Unit = request.myFoodDetails.Unit;
                _updatedFoodDetails.FoodType = request.myFoodDetails.FoodType;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
