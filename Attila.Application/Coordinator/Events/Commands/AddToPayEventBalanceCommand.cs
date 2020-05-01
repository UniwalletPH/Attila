using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class AddToPayEventBalanceCommand : IRequest<int>
    {
        public EventDetailsVM MyEventDetailsVM { get; set; }

        public class AddToPayEventBalanceCommandHandler : IRequestHandler<AddToPayEventBalanceCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public AddToPayEventBalanceCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(AddToPayEventBalanceCommand request, CancellationToken cancellationToken)
            {
                var _getEvent = dbContext.Events.Find(request.MyEventDetailsVM.ID);

                if (_getEvent != null)
                {
                    _getEvent.ToPay += request.MyEventDetailsVM.ToPay;
                    await dbContext.SaveChangesAsync();

                    return request.MyEventDetailsVM.ID;
                }
                else
                {
                    throw new Exception();
                }

            }
        }
    }
}
