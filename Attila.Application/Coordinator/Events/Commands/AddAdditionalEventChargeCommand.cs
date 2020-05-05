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
    public class AddAdditionalEventChargeCommand : IRequest<bool>
    {
        public AdditionalEventFeeVM MyAdditionalEventFeeVM  { get; set; }

        public class AddAdditionalEventChargeCommandHandler : IRequestHandler<AddAdditionalEventChargeCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;
            public AddAdditionalEventChargeCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddAdditionalEventChargeCommand request, CancellationToken cancellationToken)
            {
                EventFee _additionalEventFee = new EventFee
                {
                    EventID = request.MyAdditionalEventFeeVM.EventID,
                    Description = request.MyAdditionalEventFeeVM.Description,
                    Item = request.MyAdditionalEventFeeVM.Item,
                    Quantity = request.MyAdditionalEventFeeVM.Quantity,
                    PricePerQuantity = request.MyAdditionalEventFeeVM.PricePerQuantity,
                    TotalPrice = request.MyAdditionalEventFeeVM.PricePerQuantity * request.MyAdditionalEventFeeVM.Quantity
                };

                dbContext.EventFees.Add(_additionalEventFee);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
