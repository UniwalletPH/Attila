using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class GetEventAdditionalChargesQuery : IRequest<List<AdditionalEventFeeVM>>
    {
        public int EventID { get; set; }

        public class GetEventAdditionalChargesQueryHandler : IRequestHandler<GetEventAdditionalChargesQuery, List<AdditionalEventFeeVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetEventAdditionalChargesQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<AdditionalEventFeeVM>> Handle(GetEventAdditionalChargesQuery request, CancellationToken cancellationToken)
            {
                List<AdditionalEventFeeVM> _eventAdditionalChargesList = new List<AdditionalEventFeeVM>();

                var _getEventAdditionalCharges = dbContext.EventFees.Where(a => a.EventID == request.EventID);

                if (_getEventAdditionalCharges != null)
                {
                    foreach (var item in _getEventAdditionalCharges)
                    {
                        AdditionalEventFeeVM _eventAdditionalCharge = new AdditionalEventFeeVM
                        {
                            EventID = item.EventID,
                            Description = item.Description,
                            Item = item.Item,
                            Quantity = item.Quantity,
                            PricePerQuantity = item.PricePerQuantity,
                            TotalPrice = item.TotalPrice
                        };

                        _eventAdditionalChargesList.Add(_eventAdditionalCharge);
                    }

                    return _eventAdditionalChargesList;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}


