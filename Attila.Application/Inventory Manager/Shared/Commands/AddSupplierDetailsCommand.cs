using Attila.Application.Interfaces;
using Attila.Application.Inventory_Manager.Shared.Queries;
using Attila.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Shared.Commands
{
    public class AddSupplierDetailsCommand : IRequest<bool>
    {
        public SuppliersDetailsVM MySuppliersDetailsVM { get; set; }

        public class AddSupplierDetailsCommandHandler : IRequestHandler<AddSupplierDetailsCommand, bool>
        {
            private readonly IAttilaDbContext dbContext;

            public AddSupplierDetailsCommandHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(AddSupplierDetailsCommand request, CancellationToken cancellationToken)
            {
                Supplier supplierDetails = new Supplier
                {
                    ID = request.MySuppliersDetailsVM.ID,
                    Name = request.MySuppliersDetailsVM.Name,
                    Address = request.MySuppliersDetailsVM.Address,
                    ContactNumber = request.MySuppliersDetailsVM.ContactNumber,
                    ContactPersonName = request.MySuppliersDetailsVM.ContactPersonName
                };

                dbContext.Suppliers.Add(supplierDetails);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
