using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;

namespace Attila.Presentation.Coordinator
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
        static void Main(string[] args)
        {
            Console.WriteLine("Event Manager");
            Console.WriteLine();
            Console.WriteLine("1 - Add Event");
            Console.WriteLine("2 - Add Event Package");
            Console.WriteLine("3 - Update Event");
            Console.WriteLine("4 - Update Event Package");

        start:

            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":
                    goto start;
                default:
                    break;
            }
        }
    }
}
