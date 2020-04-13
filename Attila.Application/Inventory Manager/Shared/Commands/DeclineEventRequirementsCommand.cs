using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Commands
{
    public class DeclineEventRequirementsCommand : IRequest<bool>
    {
        public int DeclineEventID { get; set; }
        public class DeclineEventRequirementsCommandHandler : IRequestHandler<DeclineEventRequirementsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineEventRequirementsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeclineEventRequirementsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var _declineId = dbContext.Events.Where(a => a.ID == request.DeclineEventID                                                                 a.EventStatus == Status.Approved).SingleOrDefault();

                    if (_declineId != null)
                    {
                        _declineId.EventStatus = Status.CheckingRequirements;
                        await dbContext.SaveChangesAsync();
                    }

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
