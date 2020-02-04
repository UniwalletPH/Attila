using Attila.Domain.Entities.Tables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Event.Queries
{
    public class ViewAdditionalDurationRequestListQuery : IRequest<PackageAdditionalDurationRequest>
    {
        public PackageAdditionalDurationRequest AdditionalPackage { get; set; }

        public class ViewAdditionalDurationReuestListQueryHandler 
    }
}
