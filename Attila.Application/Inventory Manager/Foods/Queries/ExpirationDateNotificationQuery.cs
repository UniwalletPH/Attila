using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class ExpirationDateNotificationQuery : IRequest<List<FoodInventoryVM>>
    {
        public class ExpirationDateNotificationQueryHandler : IRequestHandler<ExpirationDateNotificationQuery, List<FoodInventoryVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public ExpirationDateNotificationQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<FoodInventoryVM>> Handle(ExpirationDateNotificationQuery request, CancellationToken cancellationToken)
            {
                List<FoodInventoryVM> _soonToExpireFoodList = new List<FoodInventoryVM>();

                var _getSoonToExpireFood = dbContext.FoodInventories.Where(a => a.ExpirationDate.Day == DateTime.Now.Day + 10);

                if (_getSoonToExpireFood != null)
                {
                    foreach (var item in _getSoonToExpireFood)
                    {
                        FoodInventoryVM _foodDetails = new FoodInventoryVM
                        {
                            FoodDetailsVM = item.Food,
                            ExpirationDate = item.ExpirationDate,
                            EncodingDate = item.EncodingDate,
                            Quantity = item.Quantity,
                            ItemPrice = item.ItemPrice,
                            Remarks = item.Remarks,
                            DeliveryDetailsID = item.DeliveryID
                        };

                        _soonToExpireFoodList.Add(_foodDetails);
                    }
                }

                return _soonToExpireFoodList;
            }
        }
    }
}
