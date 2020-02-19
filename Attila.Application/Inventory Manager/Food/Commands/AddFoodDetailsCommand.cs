using Attila.Application.Interfaces;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class AddFoodDetailsCommand : IRequest<bool>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public UnitType Unit { get; set; }

        public FoodType FoodType { get; set; }

        public class AddFoodDetailsInventoryCommandHandler : IRequestHandler<AddFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                FoodDetails _foodDetails = new FoodDetails
                {
                    Code = request.Code,
                    Name = request.Name,
                    Specification = request.Specification,
                    Description = request.Description,
                    Unit = request.Unit,
                    FoodType = request.FoodType
                };

                dbContext.FoodsDetails.Add(_foodDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
