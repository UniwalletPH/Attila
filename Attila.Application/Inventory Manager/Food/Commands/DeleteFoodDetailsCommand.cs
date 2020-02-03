using Atilla.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Food.Commands
{
    public class DeleteFoodDetailsCommand : IRequest<bool>
    {
        public int DeleteSearchedID { get; set; }

        public class DeleteFoodDetailsInventoryCommandHandler : IRequestHandler<DeleteFoodDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public DeleteFoodDetailsInventoryCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<bool> Handle(DeleteFoodDetailsCommand request, CancellationToken cancellationToken)
            {
                var _deleteFoodDetails = dbContext.FoodsDetails.Find(request.DeleteSearchedID);

                if (_deleteFoodDetails != null)
                {
                    dbContext.FoodsDetails.Remove(_deleteFoodDetails);

                    var _deleteFoodInventory = dbContext.FoodsInventory.Where(a => a.FoodDetailsID == request.DeleteSearchedID).ToList();
                    dbContext.FoodsInventory.RemoveRange(_deleteFoodInventory);
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
