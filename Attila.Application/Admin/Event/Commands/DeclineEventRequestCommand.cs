﻿using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Admin.Event.Commands
{
    public class DeclineEventRequestCommand : IRequest<int>
    {
       public int EventID { get; set; }

        public class DeclineEventRequestCommandHandler : IRequestHandler<DeclineEventRequestCommand, int>
        {
            private readonly IAttilaDbContext dbContext;
            public DeclineEventRequestCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(DeclineEventRequestCommand request, CancellationToken cancellationToken)
            {
                var _toDecline = dbContext.EventDetails.Find(request.EventID);

                if (_toDecline != null)
                {
                    _toDecline.EventStatus = Status.Declined;

                    await dbContext.SaveChangesAsync();

                    return _toDecline.ID;
                }
                else
                {
                    throw new Exception("Does not exist!");
                }            
            }
        }
    }
}
