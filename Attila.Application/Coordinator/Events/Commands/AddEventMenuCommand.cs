using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Commands
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
                foreach (var item in request.EventMenu)
                {
                    var EventMenus = new EventMenu
                    {
                        EventID = item.EventDetailsID,
                        DishID = item.MenuID
                        
                    };
                    dbContext.EventMenus.Add(EventMenus);
                    await dbContext.SaveChangesAsync();
                }
                return true;
            }
        }
    }
}
