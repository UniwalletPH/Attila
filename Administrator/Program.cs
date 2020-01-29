using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;

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
                        Console.WriteLine("{0}    {1}    {2}    {3}", item.Code, item.EventName, item.Address, item.EventStatus);

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


            }
        }
    }
}