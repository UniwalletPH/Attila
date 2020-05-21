using System;
using System.Threading;
using System.Threading.Tasks;
using Attila.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Commands
{
    public class MarkEventAsRequirementsCompleteCommand : IRequest
    {
        #region Public members
        public int EventID { get; set; }
        #endregion

        #region Handler
        public class MarkEventAsRequirementsCompleteCommandHandler : AsyncRequestHandler<MarkEventAsRequirementsCompleteCommand>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;

            public MarkEventAsRequirementsCompleteCommandHandler(IMediator mediator, IAttilaDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }

            protected override async Task Handle(MarkEventAsRequirementsCompleteCommand request, CancellationToken cancellationToken)
            {
                var _event = await dbContext.Events
                    .SingleOrDefaultAsync(a => a.ID == request.EventID && a.EventStatus == Status.CheckingRequirements);

                if (_event != null)
                {
                    _event.EventStatus = Status.RequirementsComplete;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region Validator
        public class MarkEventAsRequirementsCompleteCommandValidator : AbstractValidator<MarkEventAsRequirementsCompleteCommand>
        {
            public MarkEventAsRequirementsCompleteCommandValidator()
            {
                // RuleFor(a => a.Prop).NotNull().MaximumLength(100);
            }
        }
        #endregion
    }
}