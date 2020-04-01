using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Attila.Application.Admin.Events.Commands
{
    public class DeclineAdditionalEquipmentRequestCommand : IRequest<int>
    {
        public int RequestID { get; set; }

        public class DeclineAdditionalEquipmentRequestCommandHandler : IRequestHandler<DeclineAdditionalEquipmentRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineAdditionalEquipmentRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(DeclineAdditionalEquipmentRequestCommand request, CancellationToken cancellationToken)
            {
                var _requestToDecline = dbContext.EquipmentRestockRequests.Find(request.RequestID);

                if (_requestToDecline != null)
                {
                    _requestToDecline.Status = Status.Declined;

                    await dbContext.SaveChangesAsync();

                    return _requestToDecline.ID;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }    
            }
        }
    }
}
