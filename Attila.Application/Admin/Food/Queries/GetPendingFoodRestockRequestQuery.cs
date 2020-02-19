﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Enums;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Food.Queries
{
    public class GetPendingFoodRestockRequestQuery : IRequest<List<FoodRequestVM>>
    {
        public class ViewPendingFoodRestockRequestQueryHandler : IRequestHandler<GetPendingFoodRestockRequestQuery, List<FoodRequestVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPendingFoodRestockRequestQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<FoodRequestVM>> Handle(GetPendingFoodRestockRequestQuery request, CancellationToken cancellationToken)
            {
                var _listPendingRequest = new List<FoodRequestVM>();

                var _pendingFoodRestock = dbContext.FoodRestockRequests
                    .Include(a => a.FoodDetails)
                    .Include(a => a.User)
                    .Where(a => a.Status == Status.Pending);

                foreach (var item in _pendingFoodRestock)
                {
                    var FoodRestockRequest = new FoodRequestVM
                    { 
                        ID = item.ID,
                        FoodDetails = item.FoodDetails,
                        Quantity = item.Quantity,
                        DateTimeRequest = item.DateTimeRequest,
                        Status = item.Status,
                        User = item.User
                    };

                    _listPendingRequest.Add(FoodRestockRequest);
                }

                return _listPendingRequest;

            }
        }
    }
}
