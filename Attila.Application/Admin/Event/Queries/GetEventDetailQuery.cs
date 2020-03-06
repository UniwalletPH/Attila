using Attila.Application.Admin.Equipment.Queries;
using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Admin.Event.Queries
{
    public class GetEventDetailQuery : IRequest<EventVM>
    {
        public int EventID { get; set; }

        public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventVM>
        {
            private readonly IAttilaDbContext dbContext;
            private readonly IMediator mediator;
            public GetEventDetailQueryHandler(IAttilaDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }

            public async Task<EventVM> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
            {
                var _eventDetail = dbContext.EventDetails
                    .Include(a => a.PackageDetails)
                    .Include(a => a.EventClient)
                    .Include(a => a.User)
                    .Where(a => a.ID == request.EventID).SingleOrDefault();

                var _additionalEquipment = await mediator.Send(new GetAdditionalEquipmentRequestListQuery {EventID = request.EventID});
                var _additionalDuration = await mediator.Send(new GetAdditionalDurationRequestQuery { EventID = request.EventID});

                var _allDetails = new EventVM
                { 
                    ID = _eventDetail.ID,
                    Code = _eventDetail.Theme,
                    EventName = _eventDetail.EventName,
                    Type = _eventDetail.Type,
                    Description = _eventDetail.Description,
                    BookingDate = _eventDetail.BookingDate,
                    Location = _eventDetail.Location,
                    EventDate = _eventDetail.EventDate,
                    Remarks = _eventDetail.Remarks,
                    Coordinator = _eventDetail.User,
                    Client = _eventDetail.EventClient,
                    EventStatus = _eventDetail.EventStatus,
                    Package = _eventDetail.PackageDetails,
                    AdditionalEquipment = _additionalEquipment,
                    AdditionalDuration = _additionalDuration
                
                };

                return _allDetails;
            }
        }
    }
}
