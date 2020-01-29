using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.Presentation.EventCoordinator;

namespace Attila.Presentation.EventCoordinator
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


            Console.WriteLine("ADMIN");
            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine("1 - VIEW EVENTS");
            Console.WriteLine("2 - VIEW NOTIFICATIONS");
            Console.WriteLine("3 - VIEW REPORTS");




        }
    }
}
