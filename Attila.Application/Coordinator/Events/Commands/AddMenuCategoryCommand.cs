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
    public class AddMenuCategoryCommand : IRequest<bool>
    {
        public MenuCategoryVM MenuCategory { get; set; }

        public class AddMenuCategoryCommandHandler :IRequestHandler<AddMenuCategoryCommand, bool>
        {
            public readonly IAttilaDbContext dbContext;
            public AddMenuCategoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }


            public async Task<bool> Handle(AddMenuCategoryCommand request, CancellationToken cancellationToken)
            {
                var _newMenuCategory = new MenuCategory
                {
                    Category = request.MenuCategory.Category,
                };

                dbContext.MenuCategories.Add(_newMenuCategory);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
