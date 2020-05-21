using System;
using System.Linq;
using Attila.Application.Admin.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Queries
{
    public class GetMyEventsQuery : IRequest<IQueryable<EventVM>>
    {
        #region Public members

        #endregion

        #region Handler
        public class GetMyEventsQueryHandler : RequestHandler<GetMyEventsQuery, IQueryable<EventVM>>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;
            private readonly ICurrentUser currentUser;

            public GetMyEventsQueryHandler(IMediator mediator, IAttilaDbContext dbContext, ICurrentUser currentUser)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.currentUser = currentUser;
            }

            protected override IQueryable<EventVM> Handle(GetMyEventsQuery request)
            {
                if (!currentUser.IsInRole(AccessRole.Coordinator))
                {
                    throw new Exception("Events can only be created by organizer");
                }

                return dbContext.Events
                         .Include(a => a.EventPackage)
                         .Include(a => a.Coordinator)
                         .Include(a => a.Client)
                         .Where(a => a.CoordinatorID == currentUser.ID)
                     .Select(a => new EventVM
                     {
                         ID = a.ID,
                         EventName = a.EventName,
                         Location = a.Location,
                         BookingDate = a.BookingDate,
                         EventDate = a.EventDate,
                         Description = a.Description,
                         Type = a.Type,
                         Package = a.EventPackage,
                         Coordinator = a.Coordinator,
                         Client = a.Client,
                         EventStatus = a.EventStatus,
                         Remarks = a.Remarks,
                         AdminRemarks = a.AdminRemarks
                     });
            }
        }
        #endregion
    }
}