using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Event.Queries
{
    public class ViewEventPackageQuery : IRequest<List<EventPackageDetails>>
    {
        public ViewEventPackageQuery()
        {

        }

        public class ViewEventPackageQueryHandler : IRequestHandler<ViewEventPackageQuery, List<EventPackageDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewEventPackageQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<List<EventPackageDetails>> Handle(ViewEventPackageQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
