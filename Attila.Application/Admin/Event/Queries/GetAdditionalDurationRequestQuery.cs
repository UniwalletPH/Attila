using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetAdditionalDurationRequestQuery : IRequest<EventAdditionalDurationRequest>
    {
        public int EventID { get; set; }

        public class GetAdditionalDurationRequestQueryHandler : IRequestHandler<GetAdditionalDurationRequestQuery, EventAdditionalDurationRequest>
        {
            private readonly IAttilaDbContext dbContext;
            public GetAdditionalDurationRequestQueryHandler (IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<EventAdditionalDurationRequest> Handle(GetAdditionalDurationRequestQuery request, CancellationToken cancellationToken)
            {
                var _request = dbContext.EventAdditionalDurationRequests.Find(request.EventID);

                return _request;
            }
        }

    }
}
