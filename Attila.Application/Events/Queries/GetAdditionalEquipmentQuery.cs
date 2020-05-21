using System;
using System.Linq;
using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Queries
{
    public class GetAdditionalEquipmentQuery : IRequest<IQueryable<AdditionalEquipmentRequestListVM>>
    {
        #region Public members
        public int EventID { get; set; }
        #endregion

        #region Handler
        public class GetAdditionalEquipmentQueryHandler : RequestHandler<GetAdditionalEquipmentQuery, IQueryable<AdditionalEquipmentRequestListVM>>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;

            public GetAdditionalEquipmentQueryHandler(IMediator mediator, IAttilaDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }

            protected override IQueryable<AdditionalEquipmentRequestListVM> Handle(GetAdditionalEquipmentQuery request)
            {
                return dbContext.EventEquipmentRequestCollections
                   .Where(a => a.EventAdditionalEquipmentRequest.EventID == request.EventID)
                   .Include(a => a.Equipment)
                   .Select(a => new AdditionalEquipmentRequestListVM
                   {
                       ID = a.ID,
                       EquipmentDetails = a.Equipment,
                       Quantity = a.Quantity
                   });
            }
        }
        #endregion
    }
}