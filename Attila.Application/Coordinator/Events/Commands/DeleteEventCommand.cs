using Attila.Application.Interfaces;
using MediatR;
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
                var _eventToDelete = dbContext.EventDetails.Find(request.EventId);
                dbContext.EventDetails.Remove(_eventToDelete);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
