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
    public class AddEventMenuCommand : IRequest<bool>
    {
        public EventMenuVM EventMenu { get; set; }
        public class AddEventMenuCommandHandler : IRequestHandler<AddEventMenuCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;
            public AddEventMenuCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventMenuCommand request, CancellationToken cancellationToken)
            {
                var _newEventMenu = new EventMenus
                {
                    EventDetailsID = request.EventMenu.EventDetailsID,
                    MenuID = request.EventMenu.MenuID,
                };

                dbContext.EventMenus.Add(_newEventMenu);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
