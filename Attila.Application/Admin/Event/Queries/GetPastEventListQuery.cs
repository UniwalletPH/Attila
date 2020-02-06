﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Queries
{
    public class GetPastEventListQuery : IRequest<List<EventDetails>>
    {
       
        public class ViewPastEventListQueryHandler : IRequestHandler<GetPastEventListQuery, List<EventDetails>>
        {
            private readonly IAttilaDbContext dbContext;
            public ViewPastEventListQueryHandler(IAttilaDbContext dbContext)
            { 
                this.dbContext = dbContext;
            }

            public async Task<List<EventDetails>> Handle(GetPastEventListQuery request, CancellationToken cancellationToken)
            {
                var _list = dbContext.EventsDetails
                    .Where(a => a.EventDate < DateTime.Now);

                return _list.ToList();

            }
        }
    }
}
