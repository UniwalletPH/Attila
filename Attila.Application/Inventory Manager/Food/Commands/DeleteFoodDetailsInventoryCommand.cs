using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Commands
{
    public class DeleteFoodDetailsInventoryCommand : IRequest<bool>
    {
        private readonly int deleteSearchedID;
        public DeleteFoodDetailsInventoryCommand(int deleteSearchedID)
        {
            this.deleteSearchedID = deleteSearchedID;
        }

        public class DeleteFoodDetailsInventoryCommandHandler : IRequestHandler<DeleteFoodDetailsInventoryCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteFoodDetailsInventoryCommand request, CancellationToken cancellationToken)
            {
                var _deleteFoodDetails = dbContext.FoodsInventory.Find(request.deleteSearchedID);

                if (_deleteFoodDetails != null)
                {
                    dbContext.FoodsInventory.Remove(_deleteFoodDetails);
                }
                else
                {
                    throw new Exception("Food ID does not exist!");
                }

                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
