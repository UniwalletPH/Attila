using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;

namespace Attila.Presentation.InventoryManager
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
            Console.WriteLine("Inventory Manager");
            Console.WriteLine();
            Console.WriteLine("1 - Add Stock Details");
            Console.WriteLine("2 - View Stock Details");
            Console.WriteLine("3 - Update Stock Details");
            Console.WriteLine("4 - Delete Stock Details");

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
