using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Notification.Queries
{
    public class GetNotificationQuery : IRequest<List<NotifVM>>
    {
        public int TargetID { get; set; }

        public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, List<NotifVM>>
        {
            private readonly IAttilaDbContext dbContext;
            public GetNotificationQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<NotifVM>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
            {
                var _notifs = await dbContext.Notifications
                    .Where(a => a.TargetUserID == request.TargetID)
                    .Select(a => new NotifVM
                    {
                        Description = a.Description,
                        TargetUserID = a.TargetUserID,
                        Message = a.Messages,
                        Date = a.CreatedOn
                        

                    }).ToListAsync();


                return _notifs;
               
            }
        }

    }
}
