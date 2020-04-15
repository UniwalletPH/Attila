using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class FindAdditionalEquipmentRequestByEventIDQuery : IRequest<AdditionalEquipmentRequestVM>
    {
        public int EventID { get; set; }
        public class FindAdditionalEquipmentRequestByEventIDQueryHandler : IRequestHandler<FindAdditionalEquipmentRequestByEventIDQuery, AdditionalEquipmentRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public FindAdditionalEquipmentRequestByEventIDQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<AdditionalEquipmentRequestVM> Handle(FindAdditionalEquipmentRequestByEventIDQuery request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.EventAdditionalEquipmentRequests
                    .Where(a => a.EventID == request.EventID)
                    .SingleOrDefault();

                if (_qVal != null)
                {
                    var _request = new AdditionalEquipmentRequestVM
                    {
                        RequestID = _qVal.ID,
                        EventID = _qVal.EventID,
                        Status = _qVal.Status

                    };

                    return _request;
                }
                else
                {
                    return null;
                }

               
            }
        }
    }
}
