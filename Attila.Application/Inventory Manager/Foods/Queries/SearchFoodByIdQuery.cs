using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class SearchFoodByIdQuery : IRequest<FoodsDetailsVM>
    {
        public int SearchedID { get; set; }

        public class SearchFoodByIdQueryHandler : IRequestHandler<SearchFoodByIdQuery, FoodsDetailsVM>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByIdQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<FoodsDetailsVM> Handle(SearchFoodByIdQuery request, CancellationToken cancellationToken)
            {

                Domain.Entities.Food _searchedFoodDetails = dbContext.Foods.Find(request.SearchedID);

                if (_searchedFoodDetails != null) 
                {
                    FoodsDetailsVM searchFoodDetailsVM = new FoodsDetailsVM
                    {
                        ID = request.SearchedID,
                        Code = _searchedFoodDetails.Code,
                        Name = _searchedFoodDetails.Name,
                        Description = _searchedFoodDetails.Description,
                        Specification = _searchedFoodDetails.Specification,
                        Unit = _searchedFoodDetails.Unit,
                        FoodType = _searchedFoodDetails.FoodType
                    };
                    return searchFoodDetailsVM;
                }
                else
                {
                    throw new Exception("Food Details ID does not exist!");
                }
            }
        }
    }
}
