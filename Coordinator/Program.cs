using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Attila.Application.Admin.Queries;
using Attila.Domain.Entities.Tables;
using Attila.Application.Event.Commands;
using Attila.Domain.Enums;
using Attila.Application.Coordinator.Event.Queries;
using Attila.Domain.Entities;

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
            Console.WriteLine("6 - Update Client Details");
            Console.WriteLine("7 - Update Event Payment Status");
            Console.WriteLine("8 - Delete Event");
            Console.WriteLine("9 - Delete Event Package");
            Console.WriteLine("10 - Exit");
        
        

            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {

                #region Add Event
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

                    var _sample = await Mediator.Send(new GetClientIdCommand { FirstName = _addClientFirstName, LastName = _addClientLastName });


                    EventType _eventType = (EventType)Enum.Parse(typeof(EventType), _addEventType);

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
                #endregion
                #region Add Additional Package
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
                #endregion
                #region Request Event Requirements
                case "3":
                    Console.Clear();
                    Console.WriteLine("REQUEST EVENT REQUIREMENTS\n");

                    Console.WriteLine("Please enter event ID:");
                    var _inputEventId = Console.ReadLine();

                    Console.WriteLine("Please enter equipment ID:");
                    var _inputEquipmentId = Console.ReadLine();

                    Console.WriteLine("Please enter equipment details:");
                    var _inputEquipmentDetails = Console.ReadLine();

                    Console.WriteLine("Please enter quantity:");
                    var _inputQuantity = Console.ReadLine();

                    int _addEventId = int.Parse(_inputEventId);
                    int _addEquipmentId = int.Parse(_inputEquipmentId);
                    int _addQuantity = int.Parse(_inputQuantity);

                    var _addRequest = new EventEquipmentRequest
                    {
                        EventDetailsID = _addEventId,
                        EquipmentDetailsID = _addEquipmentId,
                        Quantity = _addQuantity,
                        Status = Status.Pending
                    };

                    await Mediator.Send(new RequestEventRequirementsCommand { EventRequirementRequest = _addRequest });
                    Console.WriteLine("Event requirements requested!");
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
                #endregion
                #region Update Event Details
                case "4":
                    Console.Clear();
                    Console.WriteLine("UPDATE EVENT DETAILS\n");

                    Console.WriteLine("Please enter event ID: ");
                    var _inputUpdateEventId = Console.ReadLine();
                    var _addUpdateEventId = int.Parse(_inputUpdateEventId);

                    Console.WriteLine("Please enter event name: ");
                    var _inputUpdateEventName = Console.ReadLine();

                    Console.WriteLine("Please enter event code: ");
                    var _inputUpdateEventCode = Console.ReadLine();

                    Console.WriteLine("Please enter event type: ");
                    var _inputUpdateEventType = Console.ReadLine();

                    Console.WriteLine("Please enter event address: ");
                    var _inputUpdateEventAddress = Console.ReadLine();

                    /*Console.WriteLine("Please enter event date: ");
                    var _addEventDate = */

                    Console.WriteLine("Please enter event location: ");
                    var _inputUpdateEventLocation = Console.ReadLine();

                    Console.WriteLine("Please enter event description: ");
                    var _inputUpdateEventDesc = Console.ReadLine();

                    Console.WriteLine("Please enter event package: ");
                    var _inputUpdateEventPackage = Console.ReadLine();
                    var _addUpdateEventPackage = int.Parse(_inputUpdateEventPackage);

                    Console.WriteLine("Please enter event remarks: ");
                    var _inputUpdateEventRemarks = Console.ReadLine();


                    EventType _eventUpdateType = (EventType)Enum.Parse(typeof(EventType), _inputUpdateEventType);

                    var _addUpdateEventDetails = new EventDetails
                    {
                        EventClientID = _addUpdateEventId,
                        EventName = _inputUpdateEventName,
                        Code = _inputUpdateEventCode,
                        Address = _inputUpdateEventAddress,
                        Location = _inputUpdateEventLocation,
                        Remarks = _inputUpdateEventRemarks,
                        EventPackageDetailsID = _addUpdateEventPackage,
                        BookingDate = DateTime.Now,
                        Description = _inputUpdateEventDesc,
                        Type = _eventUpdateType
                    };


                    await Mediator.Send(new UpdateEventCommand { UpdateEvent = _addUpdateEventDetails });
                    Console.WriteLine("Event updated successfully!");
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
                #endregion
                #region Update Package Details
                case "5":
                    Console.Clear();
                    Console.WriteLine("UPDATE PACKAGE DETAILS\n");

                    Console.WriteLine("Please enter package ID: ");
                    var _inputUpdatePackageId = Console.ReadLine();

                    Console.WriteLine("Please enter package name: ");
                    var _inputUpdatePackageName = Console.ReadLine();

                    Console.WriteLine("Please enter package description: ");
                    var _inputUpdatePackageDesc = Console.ReadLine();

                    Console.WriteLine("Please enter pax: ");
                    var _inputUpdatePackageGuest = Console.ReadLine();
                    int _addUpdatePackageGuest = int.Parse(_inputUpdatePackageGuest);

                    Console.WriteLine("Please enter package rate: ");
                    var _inputUpdatePackageRate = Console.ReadLine();
                    var _addUpdatePackageRate = Decimal.Parse(_inputUpdatePackageRate);

                    Console.WriteLine("Please enter package duration: ");
                    var _inputUpdatePackageDuration = Console.ReadLine();
                    TimeSpan _updateTimeSpan = TimeSpan.FromMinutes(double.Parse(_inputUpdatePackageDuration));

                    var _updatePackage = new EventPackageDetails
                    {
                        Code = _inputUpdatePackageName,
                        Description = _inputUpdatePackageDesc,
                        Duration = _updateTimeSpan,
                        NumberOfGuest = _addUpdatePackageGuest,
                        Rate = _addUpdatePackageRate
                    };
                    await Mediator.Send(new AddEventPackageCommand { PackageDetails = _updatePackage });
                    Console.WriteLine("Package updated successfully!");
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
                #endregion
                #region Update Client Details
                case "6":
                    Console.Clear();

                    Console.WriteLine("UPDATE CLIENT INFORMATION\n ");

                    Console.WriteLine("Please enter client ID: ");
                    var _inputUpdateClientId = Console.ReadLine();
                    int _addUpdateClientId = int.Parse(_inputUpdateClientId);

                    Console.WriteLine("Please enter client's last name: ");
                    var _inputUpdateClientLastName = Console.ReadLine();

                    Console.WriteLine("Please enter client's first name: ");
                    var _inputUpdateClientFirstName = Console.ReadLine();

                    Console.WriteLine("Please enter client's email: ");
                    var _inputUpdateClientEmail = Console.ReadLine();

                    Console.WriteLine("Please enter client's contact number: ");
                    var _inputUpdateClientContact = Console.ReadLine();

                    Console.WriteLine("Please enter client's address: ");
                    var _inputUpdateClientAddress = Console.ReadLine();

                    var _inputUpdateClientDetails = new EventClient
                    {
                        ID = _addUpdateClientId,
                        Address = _inputUpdateClientAddress,
                        Contact = _inputUpdateClientContact,
                        Email = _inputUpdateClientEmail,
                        Firstname = _inputUpdateClientFirstName,
                        Lastname = _inputUpdateClientLastName,

                    };

                    await Mediator.Send(new AddClientDetailsCommand { EventClient = _inputUpdateClientDetails });
                    Console.WriteLine("Client details updated successfully!");
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
                #endregion
                #region Update Client Payment Status
                case "7":
                    Console.Clear();

                    Console.WriteLine("UPDATE EVENT PAYMENT STATUS\n ");

                    Console.WriteLine("Please enter event ID: ");
                    var _inputUpdatePaymentId = Console.ReadLine();
                    int _addUpdatePaymentId = int.Parse(_inputUpdatePaymentId);

                    Console.WriteLine("Please enter client's last name: ");
                    var _inputUpdatePaymentLastName = Console.ReadLine();

                    Console.WriteLine("Please enter client's first name: ");
                    var _inputUpdatePaymentFirstName = Console.ReadLine();

                    Console.WriteLine("Please enter client's email: ");
                    var _inputUpdatePaymentEmail = Console.ReadLine();

                    Console.WriteLine("Please enter client's contact number: ");
                    var _inputUpdatePaymentContact = Console.ReadLine();

                    Console.WriteLine("Please enter client's address: ");
                    var _inputUpdatePaymentAddress = Console.ReadLine();

                    var _inputUpdatePaymentDetails = new EventClient
                    {
                        ID = _addUpdatePaymentId,
                        Address = _inputUpdatePaymentAddress,
                        Contact = _inputUpdatePaymentContact,
                        Email = _inputUpdatePaymentEmail,
                        Firstname = _inputUpdatePaymentFirstName,
                        Lastname = _inputUpdatePaymentLastName,

                    };

                    await Mediator.Send(new AddClientDetailsCommand { EventClient = _inputUpdatePaymentDetails });
                    Console.WriteLine("Payment status updated successfully!");
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
                #endregion
                #region Delete Event
                case "8":
                    Console.WriteLine("DELETE EVENT\n ");

                    Console.WriteLine("Please enter event ID: ");
                    var _inputDeleteEventId = Console.ReadLine();
                    int _addDeleteEventId = int.Parse(_inputDeleteEventId);

                    await Mediator.Send(new DeleteEventCommand { EventId = _addDeleteEventId });
                    Console.WriteLine("Package deleted successfully!");
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
                #endregion
                #region Delete Event Package
                case "9":
                    Console.WriteLine("DELETE EVENT PACKAGE\n ");

                    Console.WriteLine("Please enter event package ID: ");
                    var _inputDeletePackageId = Console.ReadLine();
                    int _addDeletePackageId = int.Parse(_inputDeletePackageId);

                    await Mediator.Send(new DeleteEventPackageCommand { PackageId = _addDeletePackageId });
                    Console.WriteLine("Package deleted successfully!");
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
                    #endregion
                default:
                    break;
            }
        }
    }
}
