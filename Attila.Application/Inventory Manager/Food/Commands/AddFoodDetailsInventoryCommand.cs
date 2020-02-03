﻿using Atilla.Application.Interfaces;
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

        public FoodDetails MyFoodDetails { get; set; }

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
                    Code = request.MyFoodDetails.Code,
                    Name = request.MyFoodDetails.Name,
                    Specification = request.MyFoodDetails.Specification,
                    Description = request.MyFoodDetails.Description,
                    Unit = request.MyFoodDetails.Unit,
                    FoodType = request.MyFoodDetails.FoodType
                };

                dbContext.FoodsDetails.Add(_foodDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
