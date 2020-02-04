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
            Console.WriteLine("1 - VIEW PENDING EVENT LIST");
            Console.WriteLine("2 - VIEW PAST EVENTS LIST");
            Console.WriteLine("3 - VIEW PENDING FOOD RESTOCK REQUEST");
            Console.WriteLine("4 - VIEW REPORTS");



        start:
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                    Console.WriteLine(" VIEW EVENT LIST");

                    var _pendingEventList = await Mediator.Send(new ViewAllPendingEventsQuery());


                    foreach (var item in _pendingEventList)
                    {
                        Console.WriteLine("{0}    {1}    {2}    {3}   {4}",item.ID, item.Code, item.EventName, item.Address, item.EventStatus);

                    }

                    Console.WriteLine("SELECT EVENT");
                    Console.WriteLine("ENTER EVENT ID TO APPROVE/DECLINE");
                    var _selectedID = Console.ReadLine();
                    var _toSearchID = Int32.Parse(_selectedID);



                    var _eventSelected = await Mediator.Send(new SearchEventByIdQuery { EventId = _toSearchID});


                    Console.WriteLine("{0}    {1}    {2}    {3}   {4}", _eventSelected.ID, _eventSelected.Code, _eventSelected.EventName, _eventSelected.Address, _eventSelected.EventStatus);

                    Console.WriteLine("EVENT REQUIREMENTS");
                    var _equipmentRequest = await Mediator.Send(new ViewEventEquipmentRequestQuery { EventID = _toSearchID});

                    foreach (var item in _equipmentRequest)
                    {
                        Console.WriteLine("{0}    {1}  ", item.EquipmentDetails.Name, item.Quantity);

                    }


                    Console.WriteLine("EVENT ADDITIONAL EQUIPMENT REQUEST");

                    var _additionalEquipmentRequest = await Mediator.Send(new ViewAdditionalEquipmentRequestListQuery { EventID = _toSearchID});

                    foreach (var item in _additionalEquipmentRequest)
                    {
                        Console.WriteLine("{0}    {1}  ", item.EquipmentDetails.Name , item.Quantity, item.Rate );

                    }




                    Console.WriteLine("1 = APPROVE | 2 = DECLINE ");
                    string _optionNumber = Console.ReadLine();

                    if (_optionNumber == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveEventRequestCommand { EventID = _toSearchID });

                    }

                    else if (_optionNumber == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineEventRequestCommand { EventID = _toSearchID});

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }



                    goto start;


                case "2":


                    Console.WriteLine("VIEW PAST EVENTS");

                    var _pastEventsList = await Mediator.Send(new ViewPastEventListQuery());

                    foreach (var item in _pastEventsList)
                    {
                        Console.WriteLine("{0}    {1}    {2}    {3}", item.Code, item.EventName, item.Address, item.EventStatus);

                    }


                    goto start;

                case "3":


                    Console.WriteLine("VIEW PENDING FOOD RESTOCK REQUESTS");

                    var _pendingFoodRequest = await Mediator.Send(new ViewAllFoodRestockRequestListQuery {});

                    foreach (var item in _pendingFoodRequest)
                    {
                        Console.WriteLine("{0}    {1}    {2}    {3}   {4}",item.FoodDetails.Name, item.Quantity, item.Status );

                    }

                    Console.WriteLine("SELECT REQUEST");
                    Console.WriteLine("ENTER EVENT ID TO APPROVE/DECLINE");
                    var _selected = Console.ReadLine();
                    var _selectID = Int32.Parse(_selected);




                    Console.WriteLine("1 = APPROVE | 2 = DECLINE ");
                    string _num = Console.ReadLine();

                    if (_num == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveFoodRestockRequestCommand { RequestID = _selectID });

                    }

                    else if (_num == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineFoodRestockRequestCommand { RequestID = _selectID });

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }



                    goto start;

                case "4":


                    Console.WriteLine("VIEW REPORTS");


                    goto start;


                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;

            }
        }

       
    }
}