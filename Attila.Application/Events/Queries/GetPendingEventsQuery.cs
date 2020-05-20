using System;
using System.Collections.Generic;
using System.Linq;
using Attila.Application.Admin.Events.Queries;
using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Queries
{
    public class GetPendingEventsQuery : IRequest<IQueryable<EventVM>>
    {
        #region Public members

        #endregion

        #region Handler
        public class GetPendingEventsQueryHandler : RequestHandler<GetPendingEventsQuery, IQueryable<EventVM>>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;
            private readonly ICurrentUser currentUser;

            public GetPendingEventsQueryHandler(IMediator mediator, IAttilaDbContext dbContext, ICurrentUser currentUser)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.currentUser = currentUser;
            }

            protected override IQueryable<EventVM> Handle(GetPendingEventsQuery request)
            {
                IQueryable<Event> _query = null;

                if (currentUser.IsInRole(AccessRole.Coordinator))
                {
                    _query = dbContext.Events
                        .Include(a => a.EventPackage)
                        .Include(a => a.Coordinator)
                        .Include(a => a.Client)
                        .Where(a => a.EventStatus == Status.Processing && a.CoordinatorID == currentUser.ID);
                }
                else if (currentUser.IsInRole(AccessRole.Admin))
                {
                    _query = dbContext.Events
                       .Include(a => a.EventPackage)
                       .Include(a => a.Coordinator)
                       .Include(a => a.Client)
                       .Where(a => a.EventStatus == Status.ForApproval || a.EventStatus == Status.Declined);
                }

                if (_query == null)
                {
                    return new List<EventVM>().AsQueryable();
                }

                return _query
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