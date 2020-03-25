using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class GetSupplierDetailsQuery : IRequest<IEnumerable<SuppliersDetailsVM>>
    {
        public class GetSupplierDetailsQueryHandler : IRequestHandler<GetSupplierDetailsQuery, IEnumerable<SuppliersDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public GetSupplierDetailsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<SuppliersDetailsVM>> Handle(GetSupplierDetailsQuery request, CancellationToken cancellationToken)
            {
                var _supplierDetailsList = await dbContext.SupplierDetails.Select(a => new SuppliersDetailsVM 
                { 
                    ID = a.ID,
                    Name = a.Name,
                    Address = a.Address,
                    ContactNumber = a.ContactNumber,
                    ContactPersonName = a.ContactPersonName

                }).ToListAsync();

                return _supplierDetailsList;
            }
        }
    }
}
