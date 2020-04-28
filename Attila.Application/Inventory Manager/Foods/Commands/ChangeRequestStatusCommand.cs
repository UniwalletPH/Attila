using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Commands
{
    public class ChangeRequestStatusCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public class ChangeRequestStatusCommandHandler : IRequestHandler<ChangeRequestStatusCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public ChangeRequestStatusCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ChangeRequestStatusCommand request, CancellationToken cancellationToken)
            {
                var _foodRestock= dbContext.FoodRestockRequests.Find(request.ID);

                _foodRestock.Status = Status.ForApproval;
                await dbContext.SaveChangesAsync();


                return true;

            }
        }
    }
}
