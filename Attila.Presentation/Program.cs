using MediatR;
using System;
using Attila.Application;
using Attila.Domain;
using System.Threading.Tasks;

namespace Attila.Presentation
{
    public class Program
    {
        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<>
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("STUDENT ENROLLMENT SYSTEM");
            Console.WriteLine();
            Console.WriteLine("1 - Create Student Information");
            Console.WriteLine("2 - Read Student Information");
            Console.WriteLine("3 - Update Student Information");
            Console.WriteLine("4 - Delete Student Information");
            Console.WriteLine("5 - Search Student By ID");
            Console.WriteLine("6 - Search Student By Keyword");
            Console.WriteLine("7 - Add Subjects");
            Console.WriteLine("8 - Search Student Subjects By ID");
            Console.WriteLine("9 - Delete Student Subjects By ID");
            Console.WriteLine("10 - Student Daily Time Record - Time In");
            Console.WriteLine("11 - Student Daily Time Record - Time Out");
            Console.WriteLine("15 - EXIT");
        }

    }
}
