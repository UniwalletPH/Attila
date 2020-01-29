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
    public class AddFoodDetailsInventoryCommand : IRequest<bool>
    {
        public readonly FoodDetails myFoodDetails;
        public AddFoodDetailsInventoryCommand(FoodDetails myFoodDetails)
        {
            this.myFoodDetails = myFoodDetails;
        }

        public class AddFoodDetailsInventoryCommandHandler : IRequestHandler<AddFoodDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddFoodDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                FoodDetails _foodDetails = new FoodDetails
                {
                    Code = request.myFoodDetails.Code,
                    Name = request.myFoodDetails.Name,
                    Specification = request.myFoodDetails.Specification,
                    Description = request.myFoodDetails.Description,
                    Unit = request.myFoodDetails.Unit,
                    FoodType = request.myFoodDetails.FoodType
                };

                dbContext.FoodsDetails.Add(_foodDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
