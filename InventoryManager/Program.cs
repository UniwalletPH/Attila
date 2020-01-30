using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;

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

        static void Main(string[] args)
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
                    Console.WriteLine();
                    Console.WriteLine("5 - Request Food Restock Delivery");
                    Console.WriteLine("6 - Update Food Stock Inventory");
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
                        #region Add Food Stock Details Command
                        case "1":

                            goto foodsubstart;
                        #endregion


                        #region View Food Stock Details Command
                        case "2":

                            goto foodsubstart;
                        #endregion


                        #region Update Food Stock Details Command
                        case "3":

                            goto foodsubstart;
                        #endregion


                        #region Delete Food Stock Details Command
                        case "4":

                            goto foodsubstart;
                        #endregion


                        #region Request Food Stock Delivery Command
                        case "5":

                            goto foodsubstart;
                        #endregion


                        #region Update Food Stock Inventory Command
                        case "6":

                            goto foodsubstart;
                        #endregion


                        #region Search Food by ID Command
                        case "7":

                            goto foodsubstart;
                        #endregion


                        #region Search Food by Keyword Command
                        case "8":

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
