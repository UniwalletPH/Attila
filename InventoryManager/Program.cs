using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;
using Atilla.Domain.Entities.Tables;
using Atilla.Domain.Enums;
using Atilla.Application.Food.Commands;
using Atilla.Application.Food.Queries;
using Atilla.Domain.Entities;
using Atilla.Domain.Entities.Enums;

namespace Attila.Presentation.InventoryManager
{
    public class Program
    {
        private const string V = "2";

        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<IMediator>();
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine();
            Console.WriteLine("1 - Food");
            Console.WriteLine("2 - Equipment");

            start:
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Food Commands");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add Food Stock Details");
                    Console.WriteLine("2 - View Food Stock Details");
                    Console.WriteLine("3 - Update Food Stock Details");
                    Console.WriteLine("4 - Delete Food Stock Details");
                    Console.WriteLine("5 - Update Food Stock Inventory");
                    Console.WriteLine();
                    Console.WriteLine("6 - Request Food Restock Delivery");
                    Console.WriteLine("7 - Search Food By ID");
                    Console.WriteLine("8 - Search Food By Keyword");
                    Console.WriteLine("9 - View Food Details");
                    Console.WriteLine("10 - View Food Stock Inventory");

                    foodsubstart:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Please enter a sub command: ");
                    string _subCmdNumberFood = Console.ReadLine();

                    switch (_subCmdNumberFood)
                    {
                        //case 1 : Add Food Stock Details Command
                        #region Add Food Stock Details Command
                        case "1":

                            Console.WriteLine("Add Food Stock Details");
                            Console.WriteLine();

                            Console.Write("Food Code: ");
                            var _foodCode = Console.ReadLine();

                            Console.Write("Food Name: ");
                            var _foodName = Console.ReadLine();

                            Console.Write("Food Specification: ");
                            var _foodSpecification = Console.ReadLine();

                            Console.Write("Food Description: ");
                            var _foodDescription = Console.ReadLine();

                            Console.WriteLine("Food Unit: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Food Unit: ");
                            var _foodUnit = Console.ReadLine();
                            UnitType _parsedfoodUnit = (UnitType)Enum.Parse(typeof(UnitType), _foodUnit);

                            Console.WriteLine("Food Type: ");
                            Console.WriteLine("1 - Perishable");
                            Console.WriteLine("2 - Non-perishable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Food Type: ");
                            var _foodType = Console.ReadLine();
                            FoodType _parsedFoodType = (FoodType)Enum.Parse(typeof(FoodType), _foodType);


                            FoodDetails _foodDetails = new FoodDetails
                            {
                                Code = _foodCode,
                                Name = _foodName,
                                Specification = _foodSpecification,
                                Description = _foodDescription,
                                Unit = _parsedfoodUnit,
                                FoodType = _parsedFoodType
                            };

                            var _addFoodDetailsInventoryCommand = await Mediator.Send(new AddFoodDetailsInventoryCommand { MyFoodDetails = _foodDetails});
                            if (_addFoodDetailsInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details Added to Inventory!");
                            }

                            goto foodsubstart;
                        #endregion

                        //case 2 : View Food Stock Details Query
                        #region View Food Stock Details Command
                        case "2":

                            var _viewFoodStockDetailsCommand = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodStockDetailsCommand)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);

                            }
                            goto foodsubstart;
                        #endregion

                        //case 3 : Update Food Stock Details Command
                        #region Update Food Stock Details Command
                        case "3":

                            var _viewFoodStockDetailsCommand2 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodStockDetailsCommand2)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);

                            }

                            Console.WriteLine();
                            Console.Write("Enter Food Details ID to update: ");
                            var _updateFoodID = Console.ReadLine();
                            var _updateSelectedFoodID = int.Parse(_updateFoodID);


                            Console.Write("Food Code: ");
                            var _foodCodeUpdate = Console.ReadLine();

                            Console.Write("Food Name: ");
                            var _foodNameUpdate = Console.ReadLine();

                            Console.Write("Food Specification: ");
                            var _foodSpecificationUpdate = Console.ReadLine();

                            Console.Write("Food Description: ");
                            var _foodDescriptionUpdate = Console.ReadLine();

                            Console.WriteLine("Food Unit: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Food Unit: ");
                            var _updateFoodUnit = Console.ReadLine();
                            UnitType _parsedUpdateFoodUnit = (UnitType)Enum.Parse(typeof(UnitType), _updateFoodUnit);

                            Console.WriteLine("Food Type: ");
                            Console.WriteLine("1 - Perishable");
                            Console.WriteLine("2 - Non-perishable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Food Type: ");
                            var _updateFoodType = Console.ReadLine();
                            FoodType _parsedUpdateFoodType = (FoodType)Enum.Parse(typeof(FoodType), _updateFoodType);


                            FoodDetails _foodDetailsUpdate = new FoodDetails
                            {
                                ID = _updateSelectedFoodID,
                                Code = _foodCodeUpdate,
                                Name = _foodNameUpdate,
                                Specification = _foodSpecificationUpdate,
                                Description = _foodDescriptionUpdate,
                                Unit = _parsedUpdateFoodUnit,
                                FoodType = _parsedUpdateFoodType
                            };

                            var _updateFoodDetailsInventoryCommand = await Mediator.Send(new UpdateFoodDetailsInventoryCommand {MyFoodDetails = _foodDetailsUpdate });
                            if (_updateFoodDetailsInventoryCommand == true)
                            {
                                Console.WriteLine(); 
                                Console.WriteLine("Food Details Updated!");
                            }


                            goto foodsubstart;
                        #endregion

                        //case 4 : Delete Food Stock Details Command
                        #region Delete Food Stock Details Command
                        case "4":

                            var _viewFoodStockDetailsCommand3 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodStockDetailsCommand3)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter Food ID Details to delete: ");
                            var _deleteFoodID = Console.ReadLine();
                            int _deleteSelectedFoodID = int.Parse(_deleteFoodID);

                            try
                            {
                                var _deleteFoodDetailsInventoryCommand = await Mediator.Send(new DeleteFoodDetailsInventoryCommand {DeleteSearchedID = _deleteSelectedFoodID});
                                if (_deleteFoodDetailsInventoryCommand == true)
                                {
                                    Console.WriteLine("Food Details ID {0} is Deleted!", _deleteSelectedFoodID);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine();
                                Console.WriteLine(ex.Message);
                            }

                            goto foodsubstart;
                        #endregion

                        //case 5 : Update Food Stock Inventory Command
                        #region Update Food Stock Inventory Command
                        case "6":

                            Console.WriteLine();
                            Console.WriteLine("Update Food Stock Inventory");
                            Console.WriteLine();

                            var _viewFoodStockDetailsCommand4 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodStockDetailsCommand4)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);
                            }


                            Console.Write("Enter Food ID: ");
                            var _updateID = Console.ReadLine();
                            int _updatedID = int.Parse(_updateID);

                            Console.WriteLine();
                            Console.Write("Enter New Food Stock: ");
                            var _updateStock = Console.ReadLine();
                            int _updatedFoodStock = int.Parse(_updateStock);


                            var updateFoodStockInventoryCommand = await Mediator.Send(new UpdateFoodStockInventoryCommand { SearchedID = _updatedID, NewFoodQuantity = _updatedFoodStock });


                            goto foodsubstart;
                        #endregion


                        //case 6 : Request Food Stock Delivery Command
                        #region Request Food Stock Delivery Command
                        case "5":

                            Console.WriteLine();
                            Console.Write("Enter Food ID to restock: ");
                            var _foodIdRestock = Console.ReadLine();
                            int _selectedFoodIdRestock = int.Parse(_foodIdRestock);

                            Console.Write("Enter Quantity: ");
                            var _foodRestockQuantity = Console.ReadLine();
                            int _foodRestockQuantityParsed = int.Parse(_foodRestockQuantity);

                            Console.Write("Enter User ID: ");
                            var _foodRestockUserId = Console.ReadLine();
                            int _foodRestockUserIdParsed = int.Parse(_foodRestockUserId);

                            FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                            {
                                FoodsDetailsID = _selectedFoodIdRestock,
                                Quantity = _foodRestockQuantityParsed,
                                DateTimeRequest = DateTime.Now,
                                Status = 0,
                                UserID = _foodRestockUserIdParsed
                            };

                            var _RequestFoodRestockCommand = await Mediator.Send(new RequestFoodRestockCommand { MyFoodRestockRequest = _foodRestockRequest});
                            if (_RequestFoodRestockCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Restock Successfully Requested!");
                            }

                            goto foodsubstart;
                        #endregion

                        //case 7 : Search Food by ID Query
                        #region Search Food by ID Command
                        case "7":

                            Console.WriteLine();
                            Console.WriteLine("Search Food By ID");
                            Console.Write("Enter ID: ");
                            var _searchID = Console.ReadLine();
                            int _parsedSearchID = int.Parse(_searchID);


                            var _searchFoodByIdQuaery = await Mediator.Send(new SearchFoodByIdQuery { SearchedID = _parsedSearchID});

                            goto foodsubstart;
                        #endregion


                        #region Search Food by Keyword Command
                        case "8":

                            Console.WriteLine();
                            Console.WriteLine("Enter Keyword: ");
                            var _searchKeyword = Console.ReadLine();

                            var _searchFoodByKeywordQuery = await Mediator.Send(new SearchFoodByKeywordQuery {SearchedKeyword = _searchKeyword});
                            if (_searchFoodByKeywordQuery != null)
                            {
                                foreach (var item in _searchFoodByKeywordQuery)
                                {
                                    Console.WriteLine("Searched Keyword: {0}", _searchKeyword);
                                    Console.WriteLine("Food Name: {0}   ,   Food Code: {1}", item.Name, item.Code);
                                    Console.WriteLine("Food Specification: {0}   ,   Food Description: {1}", item.Specification, item.Description);
                                }
                            }

                            goto foodsubstart;
                        #endregion


                        #region View Food Details Command
                        case "9":

                            goto foodsubstart;
                        #endregion


                        #region View Food Stock Inventory Command
                        case "10":

                            goto foodsubstart;
                        #endregion


                        default:
                            break;
                    }
                    goto start;


                case "2":

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Equipment Commands");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add Equipment Stock Details");
                    Console.WriteLine("2 - View Equipment Stock Details");
                    Console.WriteLine("3 - Update Equipment Stock Details");
                    Console.WriteLine("4 - Delete Equipment Stock Details");
                    Console.WriteLine();
                    Console.WriteLine("5 - Request Equipment Restock Delivery");
                    Console.WriteLine("6 - Update Equipment Stock Inventory");
                    Console.WriteLine("7 - Search Equipment By ID");
                    Console.WriteLine("8 - Search Equipment By Keyword");
                    Console.WriteLine("9 - View Equipment Details");
                    Console.WriteLine("10 - View Equipment Stock Inventory");

                    equipmentsubstart:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Please enter a sub command: ");
                    string _subCmdNumberEquipment = Console.ReadLine();

                    switch (_subCmdNumberEquipment)
                    {
                        #region Add Equipment Stock Details Command
                        case "1":

                            goto equipmentsubstart;
                        #endregion


                        #region View Equipment Stock Details Command
                        case "2":

                            goto equipmentsubstart;
                        #endregion


                        #region Update Equipment Stock Details Command
                        case "3":

                            goto equipmentsubstart;
                        #endregion


                        #region Delete Equipment Stock Details Command
                        case "4":

                            goto equipmentsubstart;
                        #endregion


                        #region Request Equipment Stock Delivery Command
                        case "5":

                            goto equipmentsubstart;
                        #endregion


                        #region Update Equipment Stock Inventory Command
                        case "6":

                            goto equipmentsubstart;
                        #endregion


                        #region Search Equipment by ID Command
                        case "7":

                            goto equipmentsubstart;
                        #endregion


                        #region Search Equipment by Keyword Command
                        case "8":

                            goto equipmentsubstart;
                        #endregion


                        #region View Equipment Details Command
                        case "9":

                            goto equipmentsubstart;
                        #endregion


                        #region View Equipment Stock Inventory Command
                        case "10":

                            goto equipmentsubstart;
                        #endregion

                        default:
                            break;
                    }

                    goto start;
                default:
                    break;
            }
        }
    }
}
