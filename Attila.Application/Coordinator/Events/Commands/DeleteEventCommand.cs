﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Events.Commands
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int EventId { get; set; }

        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public DeleteEventCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
            {
                var _eventToDelete = dbContext.Events.Find(request.EventId);
                dbContext.Events.Remove(_eventToDelete);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
