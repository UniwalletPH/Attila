using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Events.Queries
{
    public class GetApprovedEventsQuery : IRequest<IEnumerable<ApprovedEventVM>>
    {
        public class GetApprovedEventsQueryHandler : IRequestHandler<GetApprovedEventsQuery, IEnumerable<ApprovedEventVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetApprovedEventsQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<ApprovedEventVM>> Handle(GetApprovedEventsQuery request, CancellationToken cancellationToken)
            {
                List<ApprovedEventVM> _approvedEventList = new List<ApprovedEventVM>();

                var _getApprovedEventsList = dbContext.Events.Where(a => a.EventStatus == Status.Approved)
                                                             .Include(a => a.EventAdditionalEquipmentRequests)
                                                             .Include(a => a.EventEquipments);

                foreach (var item in _getApprovedEventsList)
                {
                    ApprovedEventVM _eventData = new ApprovedEventVM
                    {
                        ID = item.ID,
                        EventName = item.EventName,
                        Location = item.Location,
                        BookingDate = item.BookingDate,
                        EventDate = item.EventDate,
                        Description = item.Description,
                        Type = item.Type,
                        Coordinator = item.Coordinator,
                        Client = item.Client,
                        EventStatus = item.EventStatus,
                        Remarks = item.Remarks,
                        EventEquipment = item.EventEquipments,
                        AdditionalEquipment = item.EventAdditionalEquipmentRequests
                    };

                    _approvedEventList.Add(_eventData);
                }

                return _approvedEventList;
            }
        }
    }
}
