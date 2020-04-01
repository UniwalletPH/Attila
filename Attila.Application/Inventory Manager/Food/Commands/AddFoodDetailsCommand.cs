﻿using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Food.Queries;
using Attila.Domain.Entities;
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
        public FoodsDetailsVM MyFoodDetailsVM { get; set; }

        public class AddFoodDetailsInventoryCommandHandler : IRequestHandler<AddFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(AddFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Food _foodDetails = new Domain.Entities.Food
                {
                    Code = request.MyFoodDetailsVM.Code,
                    Name = request.MyFoodDetailsVM.Name,
                    Specification = request.MyFoodDetailsVM.Specification,
                    Description = request.MyFoodDetailsVM.Description,
                    Unit = request.MyFoodDetailsVM.Unit,
                    FoodType = request.MyFoodDetailsVM.FoodType
                };

                dbContext.FoodDetails.Add(_foodDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
