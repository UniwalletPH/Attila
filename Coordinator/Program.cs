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
using Attila.Application.Event.Queries;
using Attila.Application.Coordinator.Event.Commands;

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

            Console.WriteLine("Event Manager\n");
            Console.WriteLine("1. Commands");
            Console.WriteLine("2. Queries");
            Console.WriteLine("3. Exit");
            Console.Write("Please enter a number: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                startCommand:
                    #region Commands
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
                    Console.WriteLine("10 - Add Payment For Event ID");
                    Console.WriteLine("11 - Go Back");



                    Console.Write("Please enter a number: ");
                    string _cmdNumber2 = Console.ReadLine();

                    switch (_cmdNumber2)
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

                            Console.WriteLine("Format - (DD/MM/YYYY)");
                            Console.WriteLine("Please enter event date: ");
                            var _addEventDate = Console.ReadLine();
                            DateTime __addEventDateParsed = DateTime.Parse(_addEventDate);

                            Console.WriteLine("Please enter event location: ");
                            var _addEventLocation = Console.ReadLine();

                            Console.WriteLine("Please enter event description: ");
                            var _addEventDesc = Console.ReadLine();

                            Console.WriteLine("Please enter event package: ");
                            var _addEventPackage = Console.ReadLine();

                            Console.WriteLine("Please enter event remarks: ");
                            var _addEventRemarks = Console.ReadLine();

                            var _sample = await Mediator.Send(new GetClientIdQuery { FirstName = _addClientFirstName, LastName = _addClientLastName });


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
                                Type = _eventType,
                                EventDate = __addEventDateParsed
                            };


                            await Mediator.Send(new AddEventCommand { EventDetails = _addEventDetails });


                            Console.WriteLine("Event request done!");
                            Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                            string check = Console.ReadLine();
                            if (check.Contains("Y") || check.Contains("y"))
                            {
                                check = "";
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
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
                                goto startCommand;
                            }
                            else if (check.Contains("N") || check.Contains("n"))
                            {
                                Console.WriteLine("Thank you for using the system!");
                            }
                            break;
                        #endregion

                        #region Add Payment For Event ID
                        case "10":

                            Console.WriteLine();
                            Console.Write("Please enter event ID for payment: ");
                            var _eventIdPayment = Console.ReadLine();
                            int _parsedEventIdPayment = int.Parse(_eventIdPayment);

                            Console.Write("Please enter amount: ");
                            var _paymentAmount = Console.ReadLine();
                            decimal _parsedPaymentAmount = decimal.Parse(_paymentAmount);

                            Console.Write("Please enter reference number: ");
                            var _referenceNumber = Console.ReadLine();

                            Console.Write("Please enter remarks: ");
                            var _remarks = Console.ReadLine();

                            var _addPaymentForEvent = new EventPaymentStatus
                            {
                                EventDetailsID = _parsedEventIdPayment,
                                Amount = _parsedPaymentAmount,
                                DateOfPayment = DateTime.Now,
                                ReferenceNumber = _referenceNumber,
                                Remarks = _remarks
                            };

                            var _addPaymentForEventCommand = await Mediator.Send(new AddPaymentForEventCommand { MyEventPaymentStatus = _addPaymentForEvent });
                            if (_addPaymentForEventCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Payment Success!");
                            }
                            else Console.WriteLine("Payment Failed!");


                            Console.WriteLine();
                            Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                            check = Console.ReadLine();
                            if (check.Contains("Y") || check.Contains("y"))
                            {
                                check = "";
                                goto startCommand;
                            }
                            else if (check.Contains("N") || check.Contains("n"))
                            {
                                Console.WriteLine("Thank you for using the system!");
                            }


                            break;
                        #endregion

                        #region Go Back
                        case "11":
                            goto start;
                        #endregion

                        default:
                            break;
                    }
                    #endregion
                    break;

                case "2":

                startQuery:
                    #region Queries
                    Console.Clear();
                    Console.WriteLine("Event Manager Queries");
                    Console.WriteLine();
                    Console.WriteLine("1 - Search Event By ID");
                    Console.WriteLine("2 - Search Event By Keyword");
                    Console.WriteLine("3 - Search Client By ID ");
                    Console.WriteLine("4 - Search Client By Keyword");
                    Console.WriteLine("5 - Get Event List");
                    Console.WriteLine("6 - Get Client List");
                    Console.WriteLine("7 - Get Client ID");
                    Console.WriteLine("8 - Get Payment Status");
                    Console.WriteLine("9 - Get Payment Status By ID");
                    Console.WriteLine("10 - Get Event Additional Duration Request List");
                    Console.WriteLine("11 - Get Event Additional Equipment Request List");
                    Console.WriteLine("12 - Go Back");

                    Console.Write("Please enter a number: ");
                    string _cmdNumber3 = Console.ReadLine();

                    switch (_cmdNumber3)
                    {
                        #region Search Event By ID
                        case "1":
                        input:
                            try
                            {
                                Console.WriteLine("Please enter the event ID: ");
                                var _inputSearchEventId = Console.ReadLine();
                                var _addSearchEventId = int.Parse(_inputSearchEventId);

                                var _searchEventByIdResult = await Mediator.Send(new SearchEventByIdQuery { EventId = _addSearchEventId });
                                if (_searchEventByIdResult != null)
                                {

                                    Console.WriteLine("Here are is the event:\n");
                                    Console.WriteLine("ID: {0}\nCode: {1}\nEvent Name: {2}\nEvent Type: {3}\nEvent Status: " +
                                        "{4}\nAddress: {5}\nBooking Date: {6}\nEvent Date: {7}\nDescription: {8}\nLocation: {9}\nRemarks: {10}",
                                        _searchEventByIdResult.ID, _searchEventByIdResult.Code, _searchEventByIdResult.EventName, _searchEventByIdResult.Type,
                                        _searchEventByIdResult.EventStatus, _searchEventByIdResult.Address, _searchEventByIdResult.BookingDate,
                                        _searchEventByIdResult.EventDate, _searchEventByIdResult.Description, _searchEventByIdResult.Location, _searchEventByIdResult.Remarks);


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check1 = Console.ReadLine();
                                    if (check1.Contains("Y") || check1.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check1.Contains("N") || check1.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto input;
                            }

                            break;
                        #endregion

                        #region Search Event By Keyword
                        case "2":
                        input2:
                            try
                            {
                                Console.WriteLine("Please enter the event ID: ");
                                var _inputSearchEventKeyword = Console.ReadLine();

                                var _searchEventByKeywordResult = await Mediator.Send(new SearchEventByKeywordQuery { EventKeyword = _inputSearchEventKeyword });
                                if (_searchEventByKeywordResult != null)
                                {
                                    Console.WriteLine("Here are is the event:\n");
                                    Console.WriteLine("ID: {0}\nCode: {1}\nEvent Name: {2}\nEvent Type: {3}\nEvent Status: " +
                                        "{4}\nAddress: {5}\nBooking Date: {6}\nEvent Date: {7}\nDescription: {8}\nLocation: {9}\nRemarks: {10}",
                                        _searchEventByKeywordResult.ID, _searchEventByKeywordResult.Code, _searchEventByKeywordResult.EventName, _searchEventByKeywordResult.Type,
                                        _searchEventByKeywordResult.EventStatus, _searchEventByKeywordResult.Address, _searchEventByKeywordResult.BookingDate,
                                        _searchEventByKeywordResult.EventDate, _searchEventByKeywordResult.Description, _searchEventByKeywordResult.Location, _searchEventByKeywordResult.Remarks);


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check2 = Console.ReadLine();
                                    if (check2.Contains("Y") || check2.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check2.Contains("N") || check2.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto input2;
                            }

                            break;
                        #endregion

                        #region Search Client By ID
                        case "3":
                        input3:
                            try
                            {
                                Console.WriteLine("Please enter the client ID: ");
                                var _inputSearchClientKeyword = Console.ReadLine();
                                var _addSearchClientKeyword = int.Parse(_inputSearchClientKeyword);

                                var _searchClientByKeywordResult = await Mediator.Send(new SearchClientByIdQuery { ClientId = _addSearchClientKeyword });
                                if (_searchClientByKeywordResult != null)
                                {
                                    Console.WriteLine("Here are is the event:\n");
                                    Console.WriteLine("ID: {0}\nLast Name: {1}\nFirst Name: {2}\nEmail: " +
                                    "{3}\nContact No.: {4}\nAddress: {5}", _searchClientByKeywordResult.ID, _searchClientByKeywordResult.Lastname,
                                    _searchClientByKeywordResult.Firstname, _searchClientByKeywordResult.Email, _searchClientByKeywordResult.Contact,
                                    _searchClientByKeywordResult.Address);


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check3 = Console.ReadLine();
                                    if (check3.Contains("Y") || check3.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check3.Contains("N") || check3.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto input3;
                            }
                            break;
                        #endregion

                        #region Search Client By Keyword
                        case "4":
                        input4:
                            try
                            {
                                Console.WriteLine("Please enter the client keyword: ");
                                var _inputSearchClientKeyword = Console.ReadLine();

                                var _searchClientByKeywordResult = await Mediator.Send(new SearchClientByKeywordQuery { Keyword = _inputSearchClientKeyword });
                                if (_searchClientByKeywordResult != null)
                                {
                                    Console.WriteLine("Here are is the client:\n");
                                    Console.WriteLine("ID: {0}\nLast Name: {1}\nFirst Name: {2}\nEmail: " +
                                    "{3}\nContact No.: {4}\nAddress: {5}", _searchClientByKeywordResult.ID, _searchClientByKeywordResult.Lastname,
                                    _searchClientByKeywordResult.Firstname, _searchClientByKeywordResult.Email, _searchClientByKeywordResult.Contact,
                                    _searchClientByKeywordResult.Address);


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check4 = Console.ReadLine();
                                    if (check4.Contains("Y") || check4.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check4.Contains("N") || check4.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto input4;
                            }
                            break;
                        #endregion

                        #region Get Event List

                        case "5":
                            try
                            {
                                var _getEventList = await Mediator.Send(new GetEventListQuery());
                                if (_getEventList != null)
                                {
                                    Console.WriteLine("Here are the list of events:\n");
                                    //Console.WriteLine("ID:\tCode:\tEvent Name:\tEvent Type:\tEvent Status:\t" +
                                    //    "Address:\tBooking Date:\tEvent Date:\tDescription:\tLocation:\tRemarks:");
                                    foreach (var item in _getEventList)
                                    {
                                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t" +
                                        //"{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}",
                                        //item.ID, item.Code, item.EventName, item.Type,
                                        //item.EventStatus, item.Address, item.BookingDate,
                                        //item.EventDate, item.Description, item.Location, item.Remarks);
                                        Console.WriteLine("ID: {0}\nCode: {1}\nEvent Name: {2}\nEvent Type: {3}\nEvent Status: " +
                                        "{4}\nAddress: {5}\nBooking Date: {6}\nEvent Date: {7}\nDescription: {8}\nLocation: {9}\nRemarks: {10}",
                                        item.ID, item.Code, item.EventName, item.Type,
                                        item.EventStatus, item.Address, item.BookingDate,
                                        item.EventDate, item.Description, item.Location, item.Remarks);
                                    }


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check5 = Console.ReadLine();
                                    if (check5.Contains("Y") || check5.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check5.Contains("N") || check5.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        #endregion

                        #region Get Client List
                        case "6":
                            try
                            {
                                var _getClientList = await Mediator.Send(new GetClientListQuery());
                                if (_getClientList != null)
                                {
                                    Console.WriteLine("Here are the list of clients:\n");
                                    foreach (var item in _getClientList)
                                    {
                                        Console.WriteLine("ID: {0}\nLast Name: {1}\nFirst Name: {2}\nEmail: " +
                                        "{3}\nContact No.: {4}\nAddress: {5}", item.ID, item.Lastname,
                                        item.Firstname, item.Email, item.Contact, item.Address);
                                    }


                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check6 = Console.ReadLine();
                                    if (check6.Contains("Y") || check6.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check6.Contains("N") || check6.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        #endregion

                        #region Get Client ID
                        case "7":
                        input5:
                            try
                            {
                                Console.WriteLine("Please enter client's last name: ");
                                var _inputGetClientLastName = Console.ReadLine();

                                Console.WriteLine("Please enter client's first name: ");
                                var _inputGetClientFirstName = Console.ReadLine();

                                var _getClientId = await Mediator.Send(new GetClientIdQuery { LastName = _inputGetClientLastName, FirstName = _inputGetClientFirstName });
                                if (_getClientId != null)
                                {

                                    Console.WriteLine("The client ID is: {0}", _getClientId.ID);

                                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                    string check7 = Console.ReadLine();
                                    if (check7.Contains("Y") || check7.Contains("y"))
                                    {
                                        goto startQuery;
                                    }
                                    else if (check7.Contains("N") || check7.Contains("n"))
                                    {
                                        Console.WriteLine("Thank you for using the system!");
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto input5;
                            }
                            break;
                        #endregion

                        #region Get Payment Status
                        case "8":

                        input6:
                            try
                            {
                                Console.WriteLine();
                                var _getPaymentStatusQuery = await Mediator.Send(new GetPaymentStatusQuery());

                                foreach (var item in _getPaymentStatusQuery)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Payment Status ID:  {0}", item.ID);
                                    Console.WriteLine("Event ID:           {0}", item.EventDetailsID);
                                    Console.WriteLine("Amount:             {0}", item.Amount);
                                    Console.WriteLine("Date of Payment:    {0}", item.DateOfPayment);
                                    Console.WriteLine("Reference Number:   {0}", item.ReferenceNumber);
                                    Console.WriteLine("Remarks:            {0}", item.Remarks);

                                }

                                Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                                string check8 = Console.ReadLine();
                                if (check8.Contains("Y") || check8.Contains("y"))
                                {
                                    goto startQuery;
                                }
                                else if (check8.Contains("N") || check8.Contains("n"))
                                {
                                    Console.WriteLine("Thank you for using the system!");
                                }
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                                goto input6;
                            }

                            break;
                        #endregion

                        #region Get Payment Status By ID
                        case "9":

                            Console.WriteLine();
                            Console.Write("Please enter Event ID: ");
                            var _searchedId = Console.ReadLine();
                            int _parsedSearchId = int.Parse(_searchedId);

                                var _getPaymentStatusByIdQuery = await Mediator.Send(new GetPaymentStatusByEventIDQuery { EventID = _parsedSearchId });
                                if (_getPaymentStatusByIdQuery != null)
                                {
                                    foreach (var item in _getPaymentStatusByIdQuery)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Payment Status ID:  {0}", item.ID);
                                        Console.WriteLine("Event ID:           {0}", item.EventDetailsID);
                                        Console.WriteLine("Amount:             {0}", item.Amount);
                                        Console.WriteLine("Date of Payment:    {0}", item.DateOfPayment);
                                        Console.WriteLine("Reference Number:   {0}", item.ReferenceNumber);
                                        Console.WriteLine("Remarks:            {0}", item.Remarks);
                                    }
                                   
                                }

                            Console.WriteLine();
                            Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                            string check9 = Console.ReadLine();
                            if (check9.Contains("Y") || check9.Contains("y"))
                            {
                                goto startQuery;
                            }
                            else if (check9.Contains("N") || check9.Contains("n"))
                            {
                                Console.WriteLine("Thank you for using the system!");
                            }

                            break;
                        #endregion

                        #region Get Event Additional Duration Request List
                        case "10":

                            var _getEventAdditionalDurationRequestList = await Mediator.Send(new GetAdditionalDurationRequestListQuery());
                            foreach (var item in _getEventAdditionalDurationRequestList)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Event Duration Request ID: {0}", item.ID);
                                Console.WriteLine("Duration: {0}", item.Duration);
                                Console.WriteLine("Rate: {0}", item.Rate);
                                Console.WriteLine("Event Details ID: {0}", item.EventDetailsID);
                            }

                            Console.WriteLine();
                            Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                            string check = Console.ReadLine();
                            if (check.Contains("Y") || check.Contains("y"))
                            {
                                goto startQuery;
                            }
                            else if (check.Contains("N") || check.Contains("n"))
                            {
                                Console.WriteLine("Thank you for using the system!");
                            }

                            break;
                        #endregion

                        #region Get Event Additional Equipment Request List
                        case "11":

                            var _getEventAdditionalEquipmentRequestList = await Mediator.Send(new GetAdditionalEquipmentRequestListQuery());
                            foreach (var item in _getEventAdditionalEquipmentRequestList)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Event Equipment Request ID: {0}", item.ID);
                                Console.WriteLine("Equipment Details ID: {0}", item.EquipmentDetailsID);
                                Console.WriteLine("Rate: {0}", item.Rate);
                                Console.WriteLine("Event Details ID: {0}", item.EventDetailsID);
                                Console.WriteLine("Status: {0}", item.Status);
                                Console.WriteLine("Quantity: {0}", item.Quantity);
                            }

                            Console.WriteLine();
                            Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                            check = Console.ReadLine();
                            if (check.Contains("Y") || check.Contains("y"))
                            {
                                goto startQuery;
                            }
                            else if (check.Contains("N") || check.Contains("n"))
                            {
                                Console.WriteLine("Thank you for using the system!");
                            }

                            break;
                        #endregion

                        #region Go Back
                        case "12":
                            goto start;
                            #endregion


                    }
                    #endregion
                    break;

                case "3":

                    #region Exit
                    Console.WriteLine("Thank you for using the system!");
                    #endregion
                    break;
            }
        }

    }
}
