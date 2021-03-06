﻿using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Notification.Commands
{
    public class AddInventoryNotificationCommand : IRequest<bool>
    {
        public string Message { get; set; }

        public int TargetUserID { get; set; }
     
        public string MethodName { get; set; }

        public int RequestID { get; set; }


        public class AddNotificationCommandHandler : IRequestHandler<AddInventoryNotificationCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddNotificationCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddInventoryNotificationCommand request, CancellationToken cancellationToken)
            {
                var _notif = new Notifications 
                {
                    TargetUserID = request.TargetUserID, 
                    Description = request.MethodName + "?id=" + request.RequestID,
                    Messages = request.Message,
                    CreatedOn = DateTime.Now
                };

                dbContext.Notifications.Add(_notif);
                await dbContext.SaveChangesAsync();


                return true ;
            }
        }
    }
}
