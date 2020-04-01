using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class UpdateFoodDetailsCommand : IRequest<bool>
    {
        public FoodsDetailsVM MyFoodDetailsVM { get; set; }

        public class UpdateFoodDetailsInventoryCommandHandler : IRequestHandler<UpdateFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodDetails = dbContext.Foods.Find(request.MyFoodDetailsVM.ID);

                if (_updatedFoodDetails != null)
                {
                    _updatedFoodDetails.Code = request.MyFoodDetailsVM.Code;
                    _updatedFoodDetails.Name = request.MyFoodDetailsVM.Name;
                    _updatedFoodDetails.Specification = request.MyFoodDetailsVM.Specification;
                    _updatedFoodDetails.Description = request.MyFoodDetailsVM.Description;
                    _updatedFoodDetails.Unit = request.MyFoodDetailsVM.Unit;
                    _updatedFoodDetails.FoodType = request.MyFoodDetailsVM.FoodType;

                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Food ID does not exist!");
                }
                
            }
        }
    }
}
