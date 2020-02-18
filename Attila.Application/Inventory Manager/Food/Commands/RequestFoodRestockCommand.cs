using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class RequestFoodRestockCommand : IRequest<bool>
    {
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public class RequestFoodRestockCommandHandler : IRequestHandler<RequestFoodRestockCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public RequestFoodRestockCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(RequestFoodRestockCommand request, CancellationToken cancellationToken)
            {
                FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                {
                    Quantity = request.Quantity,
                    DateTimeRequest = DateTime.Now,
                    FoodDetailsID = request.FoodDetailsID,
                    Status = request.Status,
                    UserID = request.UserID
                };

                dbContext.FoodRestockRequests.Add(_foodRestockRequest);
                await dbContext.SaveChangesAsync();

                return true;

            }
        }
    }
}
