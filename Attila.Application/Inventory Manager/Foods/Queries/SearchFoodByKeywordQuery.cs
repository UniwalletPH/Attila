﻿using Attila.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class SearchFoodByKeywordQuery : IRequest<IEnumerable<FoodDetailsVM>>
    {
        public string SearchedKeyword { get; set; }

        public class SearchFoodByKeywordQueryHandler : IRequestHandler<SearchFoodByKeywordQuery, IEnumerable<FoodDetailsVM>>
        {
            private readonly IAttilaDbContext dbContext;

            public SearchFoodByKeywordQueryHandler(IAttilaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<FoodDetailsVM>> Handle(SearchFoodByKeywordQuery request, CancellationToken cancellationToken)
            {
                var _searchedKeywordList = new List<FoodDetailsVM>();

                var _searchedKeyword = dbContext.Foods.Where(a => a.Name.Contains(request.SearchedKeyword) ||
                                                                         a.Code.Contains(request.SearchedKeyword) ||
                                                                         a.Specification.Contains(request.SearchedKeyword) ||
                                                                         a.Description.Contains(request.SearchedKeyword));

                if (_searchedKeyword != null)
                {
                    foreach (var item in _searchedKeyword)
                    {
                        var _searchedResult = new FoodDetailsVM
                        {
                            ID = item.ID,
                            Code = item.Code,
                            Name = item.Name,
                            Description = item.Description,
                            Specification = item.Specification,
                            Unit = item.Unit,
                            FoodType = item.FoodType
                        };
                        _searchedKeywordList.Add(_searchedResult);
                    }
                    return _searchedKeywordList;
                }
                else
                {
                    throw new Exception("Searched keyword does not exist!");
                }
                
            }
        }
    }
}
