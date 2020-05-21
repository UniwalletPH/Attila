using System;
using System.Threading;
using System.Threading.Tasks;
using Attila.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Attila.Application.Events.Commands
{
    public class MarkEventAsCheckingRequirementCommand : IRequest
    {
        #region Public members
        public int EventID { get; set; }
        #endregion

        #region Handler
        public class MarkEventAsCheckingRequirementCommandHandler : AsyncRequestHandler<MarkEventAsCheckingRequirementCommand>
        {
            private readonly IMediator mediator;
            private readonly IAttilaDbContext dbContext;

            public MarkEventAsCheckingRequirementCommandHandler(IMediator mediator, IAttilaDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }

            protected override async Task Handle(MarkEventAsCheckingRequirementCommand request, CancellationToken cancellationToken)
            {
                var _event = await dbContext.Events
                    .SingleOrDefaultAsync(a => a.ID == request.EventID && a.EventStatus == Status.Approved);

                if (_event != null)
                {
                    _event.EventStatus = Status.CheckingRequirements;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region Validator
        public class MarkEventAsCheckingRequirementCommandValidator : AbstractValidator<MarkEventAsCheckingRequirementCommand>
        {
            public MarkEventAsCheckingRequirementCommandValidator()
            {
                // RuleFor(a => a.Prop).NotNull().MaximumLength(100);
            }
        }
        #endregion
    }
}