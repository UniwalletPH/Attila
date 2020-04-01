using Attila.Application.Coordinator.Event.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Event.Commands
{
    public class AddMenuCommand : IRequest<bool>
    {
        public MenuVM PackageMenu { get; set; }

        public class AddMenuCommandHandler : IRequestHandler<AddMenuCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;
            public AddMenuCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }


            public async Task<bool> Handle(AddMenuCommand request, CancellationToken cancellationToken)
            {
                var _newMenu = new Menu
                {
                    Description = request.PackageMenu.Description,
                    MenuCategoryID = request.PackageMenu.MenuCategoryID,
                    Name = request.PackageMenu.Name
                };

                dbContext.Menus.Add(_newMenu);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
