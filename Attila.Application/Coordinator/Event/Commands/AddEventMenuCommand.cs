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
        public List<EventMenuVM> EventMenu { get; set; }
        public class AddEventMenuCommandHandler : IRequestHandler<AddEventMenuCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;
            public AddEventMenuCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventMenuCommand request, CancellationToken cancellationToken)
            {
                var _eventMenuList = new List<EventMenuVM>();

                //var _newEventMenu = new EventMenus
                //{
                //    EventDetailsID = request.EventMenu.EventDetailsID,
                //    MenuID = request.EventMenu.MenuID,
                //};
                foreach (var item in request.EventMenu)
                {
                    var EventMenus = new EventMenuVM
                    {
                        EventDetailsID = item.EventDetailsID,
                        MenuID = item.MenuID
                    };
                    _eventMenuList.Add(EventMenus);
                    await dbContext.SaveChangesAsync();
                }
                return true;
            }
        }
    }
}
