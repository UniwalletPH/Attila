using Attila.Application.Interfaces;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class UpdateFoodDetailsCommand : IRequest<bool>
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public UnitType Unit { get; set; }

        public FoodType FoodType { get; set; }

        public class UpdateFoodDetailsInventoryCommandHandler : IRequestHandler<UpdateFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public UpdateFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(UpdateFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                var _updatedFoodDetails = dbContext.FoodsDetails.Find(request.ID);

                if (_updatedFoodDetails != null)
                {
                    _updatedFoodDetails.Code = request.Code;
                    _updatedFoodDetails.Name = request.Name;
                    _updatedFoodDetails.Specification = request.Specification;
                    _updatedFoodDetails.Description = request.Description;
                    _updatedFoodDetails.Unit = request.Unit;
                    _updatedFoodDetails.FoodType = request.FoodType;

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
