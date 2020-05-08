using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class AddFoodDetailsCommand : IRequest<bool>
    {
        public FoodDetailsVM MyFoodDetailsVM { get; set; }

        public class AddFoodDetailsInventoryCommandHandler : IRequestHandler<AddFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                Food _foodDetails = new Food
                {
                    CreatedOn = DateTime.Now,
                    Code = request.MyFoodDetailsVM.Code,
                    Name = request.MyFoodDetailsVM.Name,
                    Specification = request.MyFoodDetailsVM.Specification,
                    Description = request.MyFoodDetailsVM.Description,
                    Unit = request.MyFoodDetailsVM.Unit,
                    FoodType = request.MyFoodDetailsVM.FoodType,
                    CreatedOn = DateTime.Now
                };

                dbContext.Foods.Add(_foodDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
