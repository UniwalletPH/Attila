using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class SearchPackageByIdQuery : IRequest<List<PackageMenuVM>>
    {
        public int PackageId { get; set; }
        public class SearchPackageByIdQueryHandler : IRequestHandler<SearchPackageByIdQuery, List<PackageMenuVM>>
        {
            public readonly IAttilaDbContext dbContext;
            public SearchPackageByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<PackageMenuVM>> Handle(SearchPackageByIdQuery request, CancellationToken cancellationToken)
            {
                var _searchedPackage = new List<PackageMenuVM>();

                var _package = dbContext.EventPackageDishes
                    .Include(a => a.EventPackage)
                    .Include(a => a.Dish)
                    .Where(a => a.EventPackageID == request.PackageId );

                foreach (var item in _package)
                {
                    var Packages = new PackageMenuVM
                    {
                        ID = item.ID,
                        MenuID = item.DishID,
                        PackageDetailsID = item.EventPackageID,
                        Menu = item.Dish,
                        PackageMenuDetails = item.EventPackage
                    };
                    _searchedPackage.Add(Packages);
                }

                return _searchedPackage;
            }
        }
    }
}
