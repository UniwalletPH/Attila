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
    public class FindAdditionalDishRequestByEventIDQuery : IRequest<AdditionalDishRequestVM>
    {
        public int EventID { get; set; }
        public class FindAdditionalDishRequestByEventIDQueryHandler : IRequestHandler<FindAdditionalDishRequestByEventIDQuery, AdditionalDishRequestVM>
        {
            private readonly IAttilaDbContext dbContext;
            public FindAdditionalDishRequestByEventIDQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<AdditionalDishRequestVM> Handle(FindAdditionalDishRequestByEventIDQuery request, CancellationToken cancellationToken)
            {
                var _qVal = dbContext.EventAdditionalDishRequests
                    .Where(a => a.EventID == request.EventID)
                    .SingleOrDefault();

                if (_qVal != null)
                {
                    var _request = new AdditionalDishRequestVM
                    { 
                        Event = _qVal.Event,
                        EventID = _qVal.EventID,
                        RequestID = _qVal.ID,
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
