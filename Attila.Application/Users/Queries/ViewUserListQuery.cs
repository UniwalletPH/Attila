using Attila.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Users.Queries
{

	public class ViewUserListQuery : IRequest<IEnumerable<UserVM>>
	{
		#region Public members

		#endregion

		#region Handler			
		public class ViewUserListQueryHandler : IRequestHandler<ViewUserListQuery, IEnumerable<UserVM>>
		{
			private readonly IMediator mediator;
			private readonly IAttilaDbContext dbContext;

			public ViewUserListQueryHandler(IMediator mediator, IAttilaDbContext dbContext)
			{
				this.mediator = mediator;
				this.dbContext = dbContext;
			}

			public async Task<IEnumerable<UserVM>> Handle(ViewUserListQuery request, CancellationToken cancellationToken)
			{
				var _users = await dbContext.Users
					.Include(a => a.UserLogins)
					.Where(a => a.ID > 0)
					.Select(a => new UserVM
					{
						ID = a.ID,
						UID = a.UID,
						Name = a.Name,
						Position = a.Position,
						ContactNumber = a.ContactNumber,
						Email = a.Email,
						Role = a.Role,
						Username = a.UserLogins.Username
					})
					.ToListAsync();

				return _users;
			}
		}
		#endregion
	}
}
