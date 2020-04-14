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
    public class ApproveEventRequirementsCommand : IRequest<bool>
    {
        public int ApproveEventID { get; set; }
        public class ApproveEventRequirementsCommandHandler : IRequestHandler<ApproveEventRequirementsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public ApproveEventRequirementsCommandHandler (IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ApproveEventRequirementsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var _approveId = dbContext.Events.Where(a => a.ID == request.ApproveEventID).SingleOrDefault();

                    if (_approveId != null)
                    {
                        _approveId.EventStatus = Status.ForApproval;
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
