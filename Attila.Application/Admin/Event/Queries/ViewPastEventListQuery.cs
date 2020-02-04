﻿using Atilla.Application.Interfaces;
using Atilla.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atilla.Application.Admin.Queries
{
    public class ViewPastEventListQuery : IRequest<List<EventDetails>>
    {
       
        public class ViewPastEventListQueryHandler : IRequestHandler<ViewPastEventListQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPastEventListQueryHandler(IAttilaDbContext dbContext)
            { 
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(ViewPastEventListQuery request, CancellationToken cancellationToken)
            {
                var _list = dbContext.EventsDetails
                    // TODO: this is not a past events, this is future events
                    .Where(a => a.EventDate > DateTime.Now);

                return _list.ToList();

            }
        }
    }
}
