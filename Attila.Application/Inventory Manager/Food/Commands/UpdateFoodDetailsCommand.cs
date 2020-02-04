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
    public class UpdateFoodDetailsCommand : IRequest<bool>
    {
        public FoodDetails MyFoodDetails { get; set; }

        public class UpdateFoodDetailsInventoryCommandHandler : IRequestHandler<UpdateFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodDetails = dbContext.FoodsDetails.Find(request.MyFoodDetails.ID);

                _updatedFoodDetails.Code = request.MyFoodDetails.Code;
                _updatedFoodDetails.Name = request.MyFoodDetails.Name;
                _updatedFoodDetails.Specification = request.MyFoodDetails.Specification;
                _updatedFoodDetails.Description = request.MyFoodDetails.Description;
                _updatedFoodDetails.Unit = request.MyFoodDetails.Unit;
                _updatedFoodDetails.FoodType = request.MyFoodDetails.FoodType;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
