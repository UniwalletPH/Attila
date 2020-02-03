using Atilla.Application.Interfaces;
using Attila.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Food.Commands
{
    public class DeclineFoodRestockRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class DeclineFoodRestockRequestCommandHandler : IRequestHandler<DeclineFoodRestockRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;

            public DeclineFoodRestockRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            
            }

            public async Task<int> Handle(DeclineFoodRestockRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.FoodRestockRequests.Find(request.RequestID);

                _requestToDecline.Status = Status.Declined;

                await dbContext.SaveChangesAsync();

                return _requestToDecline.ID;


            }
        }

    }
}
