using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Event.Queries
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

                var _package = dbContext.PackageMenus
                    .Include(a => a.PackageMenuDetails)
                    .Include(a => a.Menu)
                    .Where(a => a.PackageMenuDetailsID == request.PackageId);

                foreach (var item in _package)
                {
                    var Packages = new PackageMenuVM
                    {
                        ID = item.ID,
                        MenuID = item.MenuID,
                        PackageDetailsID = item.PackageMenuDetailsID,
                        Menu = item.Menu,
                        PackageMenuDetails = item.PackageMenuDetails
                    };
                    _searchedPackage.Add(Packages);
                }

                return _searchedPackage;
            }
        }
    }
}
