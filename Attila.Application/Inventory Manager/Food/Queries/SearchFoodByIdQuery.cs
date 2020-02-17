using Attila.Application.Interfaces;
using Attila.Domain.Entities.Tables;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Food.Queries
{
    public class SearchFoodByIdQuery : IRequest<FoodDetails>
    {
        public int SearchedID { get; set; }

        public class SearchFoodByIdQueryHandler : IRequestHandler<SearchFoodByIdQuery, FoodDetails>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<FoodDetails> Handle(SearchFoodByIdQuery request, CancellationToken cancellationToken)
            {
                FoodDetails _searchedFoodDetails = dbContext.FoodsDetails.Find(request.SearchedID);

                return _searchedFoodDetails;
            }
        }
    }
}
