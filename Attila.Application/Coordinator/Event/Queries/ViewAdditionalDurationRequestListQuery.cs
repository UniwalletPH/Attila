using Attila.Domain.Entities.Tables;
using MediatR;

namespace Attila.Application.Event.Queries
{
    public class ViewAdditionalDurationRequestListQuery : IRequest<PackageAdditionalDurationRequest>
    {
        public PackageAdditionalDurationRequest AdditionalPackage { get; set; }

        public class ViewAdditionalDurationReuestListQueryHandler
        {

        }
    }
}
