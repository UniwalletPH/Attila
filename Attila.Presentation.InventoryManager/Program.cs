using Attila.Presentation;
using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Presentation.EventCoordinator
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

            Console.WriteLine("Inventory Manager");
            Console.WriteLine("List of Commands");


        }
    }
}
