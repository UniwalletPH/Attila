using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Attila.Application.Admin.Event.Queries;
using Attila.Application.Admin.Equipment.Queries;
using Attila.Application.Admin.Commands;
using Attila.Application.Admin.Queries;
using Atilla.Application.Admin.Food.Queries;
using Attila.Application.Admin.Food.Commands;
using Attila.Application.Event.Queries;
using Attila.Application.Admin.Inventory.Queries;
using Attila.Application.Admin.Equipment.Commands;
using Atilla.Application.Admin.Equipment.Commands;
using Attila.Application.Admin.Food.Queries;

namespace Attila.Presentation.Administrator
{
    public class Program
    {
        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<IMediator>();
            }
        }


        static async Task Main(string[] args)
        {

            Console.WriteLine("ADMINISTRATOR");
            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine(" [1] - VIEW ALL EVENT LIST");
            Console.WriteLine(" [2] - VIEW PENDING EVENTS LIST");
            Console.WriteLine(" [3] - VIEW INCOMING EVENTS LIST");
            Console.WriteLine(" [4] - VIEW PAST EVENTS LIST");
            Console.WriteLine(" [5] - VIEW PENDING FOOD RESTOCK REQUEST");
            Console.WriteLine(" [6] - VIEW PENDING EQUIPMENT RESTOCK REQUEST");




        start:
            Console.Write("\nPlease enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {

                case "1":

                    Console.WriteLine("\t***EVENTS LIST***");
                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\t\tADDRESS\t\tSTATUS");

                    var _eventList = await Mediator.Send(new GetAllEventDetailsListQuery { });

                    foreach (var item in _eventList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", item.ID, item.Code, item.EventName, item.Address, item.EventStatus);

                    }


                    goto start;

                case "2":

                    Console.WriteLine("\t***PENDING EVENTS***");
                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\t\tADDRESS\t\tSTATUS");

                    var _pendingEventList = await Mediator.Send(new GetAllPendingEventsQuery());


                    foreach (var item in _pendingEventList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", item.ID, item.Code, item.EventName, item.Address, item.EventStatus);

                    }

                    
                    Console.WriteLine("\n\nVIEW EVENT DETAILS---");
                    Console.Write("ID#:");
                    var _selectedID = Console.ReadLine();
                    var _toSearchID = Int32.Parse(_selectedID);



                    var _eventSelected = await Mediator.Send(new SearchEventByIdQuery { EventId = _toSearchID });

                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\t\tADDRESS\t\tSTATUS");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", _eventSelected.ID, _eventSelected.Code, _eventSelected.EventName, _eventSelected.Address, _eventSelected.EventStatus);

                    Console.WriteLine("\n\n\t***EVENT REQUIREMENTS***");
                    Console.WriteLine("ITEM ID#\tCODE\t\tNAME\t\tQUANTITY\t\tUNIT");
                    var _equipmentRequest = await Mediator.Send(new GetEventEquipmentRequestQuery { EventID = _toSearchID });

                    foreach (var item in _equipmentRequest)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t\t{4}",item.EquipmentDetails.ID,item.EquipmentDetails.Code, item.EquipmentDetails.Name, item.Quantity, item.EquipmentDetails.UnitType);

                    }


                    Console.WriteLine("\n\n\t***EVENT ADDITIONAL EQUIPMENT REQUEST***");

                    var _additionalEquipmentRequest = await Mediator.Send(new Application.Admin.Equipment.Queries.GetAdditionalEquipmentRequestListQuery { EventID = _toSearchID });

                    foreach (var item in _additionalEquipmentRequest)
                    {
                        Console.WriteLine("{0}    {1}  ", item.EquipmentDetails.Name, item.Quantity, item.Rate);

                    }




                    Console.WriteLine("\n\n1 = APPROVE | 2 = DECLINE | 3 = EXIT ");
                    string _optionNumber = Console.ReadLine();

                    if (_optionNumber == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveEventRequestCommand { EventID = _toSearchID });

                    }

                    else if (_optionNumber == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineEventRequestCommand { EventID = _toSearchID });

                    }
                    else if (_optionNumber == "3")
                    {
                        goto start;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }



                    goto start;


                case "3":

                    Console.WriteLine("***EVENTS LIST***");

                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\t\tADDRESS\t\tSTATUS");

                    var _incomingEvents = await Mediator.Send(new GetAllIncomingEventsQuery());


                    foreach (var item in _incomingEvents)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", item.ID, item.Code, item.EventName, item.Address, item.EventStatus);

                    }

                    goto start;
              

                case "4":


                    Console.WriteLine("***PAST EVENTS***");

                    var _pastEventsList = await Mediator.Send(new GetPastEventListQuery());

                    foreach (var item in _pastEventsList)
                    {
                        Console.WriteLine("{0}    {1}    {2}    {3}", item.Code, item.EventName, item.Address, item.EventStatus);

                    }


                    goto start;

                case "5":


                    Console.WriteLine("***PENDING FOOD RESTOCK REQUESTS***");
                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\tQUANTITY\tUNIT");

                    var _pendingFoodRequest = await Mediator.Send(new GetPendingFoodRestockRequestQuery { });



                    foreach (var item in _pendingFoodRequest)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}",item.ID, item.FoodDetails.Code, item.FoodDetails.Name, item.Quantity,item.FoodDetails.Unit);

                    }

                    Console.WriteLine("SELECT REQUEST");
                    Console.WriteLine("ENTER REQUEST ID TO APPROVE/DECLINE");
                    var _selected = Console.ReadLine();
                    var _selectID = Int32.Parse(_selected);




                    Console.WriteLine("1 = APPROVE | 2 = DECLINE | 3 = EXIT ");
                    string _num = Console.ReadLine();

                    if (_num == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveFoodRestockRequestCommand { RequestID = _selectID });

                    }

                    else if (_num == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineFoodRestockRequestCommand { RequestID = _selectID });

                    }
                    else if (_num =="3")
                    {
                        goto start;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }



                    goto start;

                case "6":


                    Console.WriteLine("***PENDING EQUIPMENT RESTOCK REQUEST***");
                    Console.WriteLine("ID#\t\tCODE\t\tNAME\t\tQUANTITY\tUNIT");


                    var _pendingEquipmentReq = await Mediator.Send(new GetPendingEquipmentRestockRequestQuery {});

                    foreach (var item in _pendingEquipmentReq)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", item.ID,item.EquipmentDetails.Code, item.EquipmentDetails.Name, item.Quantity, item.EquipmentDetails.UnitType);
                    }


                    Console.WriteLine("SELECT REQUEST");
                    Console.WriteLine("ENTER  ID TO APPROVE/DECLINE");
                    var _selectedThing = Console.ReadLine();
                    var _selectedReqID = Int32.Parse(_selectedThing);


                    Console.WriteLine("1 = APPROVE | 2 = DECLINE | 3 = EXIT");
                    string _opNum = Console.ReadLine();

                    if (_opNum == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveEquipmentRestockRequestCommand { RequestID = _selectedReqID });

                    }

                    else if (_opNum == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineEquipmentRestockRequestCommand { RequestID = _selectedReqID });

                    }
                    else if (_opNum == "3")

                    {
                        goto start;

                    }


                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }



                    goto start;


                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;

            }
        }

       
    }
}
