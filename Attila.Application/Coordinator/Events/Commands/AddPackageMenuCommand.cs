using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
{
    public class AddPackageMenuCommand : IRequest<bool>
    {
        public PackageMenuVM PackageMenu { get; set; }
        public class AddPackageMenuCommandHandler : IRequestHandler<AddPackageMenuCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;
            public AddPackageMenuCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddPackageMenuCommand request, CancellationToken cancellationToken)
            {
                var _newPackageMenu = new EventPackageDish
                {
                    DishID = request.PackageMenu.MenuID,
                    EventPackageID = request.PackageMenu.PackageDetailsID
                };

                dbContext.EventPackageDishes.Add(_newPackageMenu);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
