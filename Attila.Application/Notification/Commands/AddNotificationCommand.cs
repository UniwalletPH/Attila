using Attila.Application.Interfaces;
using Attila.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Notification.Commands
{
    public class AddNotificationCommand : IRequest<bool>
    {
        public int TargetUserID { get; set; }
     
        public string MethodName { get; set; }

        public int RequestID { get; set; }


        public class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddNotificationCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
            {
                var _notif = new Notifications 
                {
                    TargetUserID = request.TargetUserID,
                    Description = "New Request Received , <a href =\"/Notification/" + request.MethodName+"?="+request.RequestID+"\"> CLICK HERE </a>"
                };

                dbContext.Notifications.Add(_notif);
                await dbContext.SaveChangesAsync();


                return true ;
            }
        }
    }
}
