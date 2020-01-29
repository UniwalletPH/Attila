using Atilla.Application.Admin.Queries;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Attila.Presentation.Admin
{
    public class Program
    {
        static async Task Main(string[] args)
        {


            Console.WriteLine("ADMIN");
            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine("1 - VIEW EVENTS");
            Console.WriteLine("2 - VIEW NOTIFICATIONS");
            Console.WriteLine("3 - VIEW REPORTS");

        start:
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {


                case "1":

                    Console.WriteLine("VIEW EVENTS");



                    goto start;



                case "2":

                    Console.WriteLine("VIEW NOTIFICATIONS");



                    goto start;

                case "3":

                    Console.WriteLine("VIEW REPORTS");



                    goto start;





                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;

            }
        }
    }
}