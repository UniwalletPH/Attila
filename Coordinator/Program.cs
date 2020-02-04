using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Attila.Application.Admin.Queries;
using Attila.Domain.Entities.Tables;
using Attila.Application.Event.Commands;
using Attila.Domain.Enums;
using Attila.Application.Coordinator.Event.Queries;

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
        static async Task Main(string[] args)
        {
        start:
            Console.Clear();
            Console.WriteLine("Event Manager");
            Console.WriteLine();
            Console.WriteLine("1 - Add Event");
            Console.WriteLine("2 - Add Event Package");
            Console.WriteLine("3 - Request Event Requirements");
            Console.WriteLine("4 - Update Event");
            Console.WriteLine("5 - Update Event Package");
            Console.WriteLine("6 - Update Event Payment Status");
            Console.WriteLine("7 - Delete Event");
            Console.WriteLine("8 - Delete Event Package");
            Console.WriteLine("9 - Exit");
        
        

            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("CLIENT INFORMATION\n ");

                    Console.WriteLine("Please enter client's last name: ");
                    var _addClientLastName = Console.ReadLine();

                    Console.WriteLine("Please enter client's first name: ");
                    var _addClientFirstName = Console.ReadLine();

                    Console.WriteLine("Please enter client's email: ");
                    var _addClientEmail = Console.ReadLine();

                    Console.WriteLine("Please enter client's contact number: ");
                    var _addClientContact = Console.ReadLine();

                    Console.WriteLine("Please enter client's address: ");
                    var _addClientAddress = Console.ReadLine();

                    var _addClientDetails = new EventClient
                    {
                        Address = _addClientAddress,
                        Contact = _addClientContact,
                        Email = _addClientEmail,
                        Firstname = _addClientFirstName,
                        Lastname = _addClientLastName,

                    };

                    await Mediator.Send(new AddClientDetailsCommand { EventClient = _addClientDetails });

                    Console.WriteLine("EVENT INFORMATION\n");

                    Console.WriteLine("Please enter client ID: ");
                    var _addEventClientId = Console.ReadLine();
                    int _addEventClientId2 = int.Parse(_addEventClientId);

                    Console.WriteLine("Please enter event name: ");
                    var _addEventName = Console.ReadLine();

                    Console.WriteLine("Please enter event type: ");
                    var _addEventType = Console.ReadLine();

                    Console.WriteLine("Please enter event address: ");
                    var _addEventAddress = Console.ReadLine();

                    /*Console.WriteLine("Please enter event date: ");
                    var _addEventDate = */

                    Console.WriteLine("Please enter event location: ");
                    var _addEventLocation = Console.ReadLine();

                    Console.WriteLine("Please enter event description: ");
                    var _addEventDesc = Console.ReadLine();

                    Console.WriteLine("Please enter event package: ");
                    var _addEventPackage = Console.ReadLine();

                    Console.WriteLine("Please enter event remarks: ");
                    var _addEventRemarks = Console.ReadLine();

                    var _sample = await Mediator.Send(new GetClientIdCommand {FirstName = _addClientFirstName, LastName = _addClientLastName });
                   

                    EventType _eventType = (EventType)Enum.Parse(typeof(EventType),_addEventType);

                    var _addEventDetails = new EventDetails
                    {
                        EventClientID = _sample.ID,
                        EventName = _addEventName,
                        Address = _addEventAddress,
                        Location = _addEventLocation,
                        Remarks = _addEventRemarks,
                        BookingDate = DateTime.Now,
                        Description = _addEventDesc,
                        Type = _eventType
                    };

                    
                    await Mediator.Send(new AddEventCommand { EventDetails = _addEventDetails });
                    

                    Console.WriteLine("Event request done!");
                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string check = Console.ReadLine();
                    if (check.Contains("Y") || check.Contains("y"))
                    {
                        check = "";
                        goto start;
                    }
                    else if (check.Contains("N") || check.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }

                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("ADD ADDITIONAL PACKAGE\n");

                    Console.WriteLine("Please enter package name: ");
                    var _addPackageName = Console.ReadLine();

                    Console.WriteLine("Please enter package description: ");
                    var _addPackageDesc = Console.ReadLine();

                    Console.WriteLine("Please enter pax: ");
                    var _inputPackageGuest = Console.ReadLine();
                    int _addPackageGuest = int.Parse(_inputPackageGuest);

                    Console.WriteLine("Please enter package rate: ");
                    var _inputPackageRate = Console.ReadLine();
                    var _addPackageRate = Decimal.Parse(_inputPackageRate);
                    
                    Console.WriteLine("Please enter package duration: ");
                    var _inputPackageDuration = Console.ReadLine();
                    TimeSpan timeSpan = TimeSpan.FromMinutes(double.Parse(_inputPackageDuration));

                    var _addPackage = new EventPackageDetails
                    {
                        Code = _addPackageName,
                        Description = _addPackageDesc,
                        Duration = timeSpan,
                        NumberOfGuest = _addPackageGuest,
                        Rate = _addPackageRate
                    };
                    await Mediator.Send(new AddEventPackageCommand { PackageDetails = _addPackage });
                    Console.WriteLine("Package added successfully!");
                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    check = Console.ReadLine();
                    if (check.Contains("Y") || check.Contains("y"))
                    {
                        goto start;
                    }
                    else if (check.Contains("N") || check.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
