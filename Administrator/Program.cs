using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;
using Atilla.Application.Event.Queries;
using Atilla.Application.Admin.Commands;

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
            Console.WriteLine("1 - VIEW EVENT LIST");
            Console.WriteLine("2 - VIEW PAST EVENTS LIST");
            Console.WriteLine("3 - VIEW NOTIFICATION");
            Console.WriteLine("4 - VIEW REPORTS");



        start:
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                    Console.WriteLine(" VIEW EVENT LIST");

                    var _eventList = await Mediator.Send(new ViewAllEventDetailsListQuery());


                    foreach (var item in _eventList)
                    {
                        Console.WriteLine("{0}    {1}    {2}    {3}   {4}",item.ID, item.Code, item.EventName, item.Address, item.EventStatus);

                    }

                    Console.WriteLine("SELECT EVENT");
                    Console.WriteLine("ENTER EVENT ID TO APPROVE/DECLINE");
                    var _selectedID = Console.ReadLine();
                    var _toSearchID = Int32.Parse(_selectedID);



                    var _eventSelected = await Mediator.Send(new SearchEventByIdQuery(_toSearchID));


                    Console.WriteLine("{0}    {1}    {2}    {3}   {4}", _eventSelected.ID, _eventSelected.Code, _eventSelected.EventName, _eventSelected.Address, _eventSelected.EventStatus);

                    Console.WriteLine("EVENT REQUIREMENTS");
                    Console.WriteLine("EVENT REQUIREMENTS");
                    Console.WriteLine("EVENT REQUIREMENTS");
                    Console.WriteLine("EVENT REQUIREMENTS");


                    Console.WriteLine("1 = APPROVE | 2 = DECLINE ");
                    string _optionNumber = Console.ReadLine();

                    if (_optionNumber == "1")
                    {

                        var _retVal = await Mediator.Send(new ApproveEventRequestCommand(_toSearchID));

                    }

                    else if (_optionNumber == "2")

                    {
                        var _returnID = await Mediator.Send(new DeclineEventRequestCommand(_toSearchID));

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


                    Console.WriteLine("VIEW NOTIFICATIONS");


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