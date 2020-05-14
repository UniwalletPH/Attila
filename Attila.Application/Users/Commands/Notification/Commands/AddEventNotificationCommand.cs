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
    public class AddEventNotificationCommand : IRequest<bool>
    {
        public string Message { get; set; }

        public int TargetUserID { get; set; }
     
        public string MethodName { get; set; }

        public int RequestID { get; set; }


        public class AddEventNotificationCommandHandler : IRequestHandler<AddEventNotificationCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddEventNotificationCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddEventNotificationCommand request, CancellationToken cancellationToken)
            {
                var _notif = new Notifications 
                {
                    TargetUserID = request.TargetUserID,
                    Description =  request.MethodName+ "?EventID=" + request.RequestID ,
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
