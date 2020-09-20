using System;
using System.Collections.Generic;
using Services;
using Employees;
using Patients;
using System.Text.Json;
using System.IO;

namespace mainSys
    {
        public class Msg
        {
            string content;
            string recipient;
            string sender;
        }

        class Program
        {
            static void Main()
            {
                var fileService = new FileService();
                var employeeList = new EmployeeList();
                var patientList = new PatientsList();
                var eventService = new EventService();
                eventService.Events = eventService.DeserializeEvents();
                Main2();
                void Main2(){
                    Console.WriteLine("Enter 1 to add a new event");
                    Console.WriteLine("Enter 2 to remove  an event");
                    Console.WriteLine("Enter 3 to view all events");
                    Console.WriteLine("Enter 4 to add a new employee");
                    Console.WriteLine("Enter 5 to remove an employee");
                    Console.WriteLine("Enter 6 to view employee info");
                    Console.WriteLine("Enter 7 to add a patient");
                    Console.WriteLine("Enter 8 to remove a patiet");
                    Console.WriteLine("Enter 9 to view a patients info");
                    Console.WriteLine("Enter 10 to save all added information");
                    Console.WriteLine("Enter 11 to exit program");
                    Console.WriteLine("Enter 12 to exit program");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection)
                    {
                        case (1):
                            while(true)
                            {
                                Console.WriteLine("Please enter event date and time in the following format 2020-09-06 12:35");
                                var input = Console.ReadLine();
                                try
                                {
                                    var date = DateTime.ParseExact(input, "yyyy-MM-dd HH:mm", null);
                                    Console.WriteLine("Enter the name of the event");
                                    var newEventName = Console.ReadLine();
                                    eventService.AddEventServiceDate(newEventName, date); 
                                    Console.WriteLine("Thank you");
                                    break;
                                }
                                catch(FormatException e)
                                {
                                    Console.WriteLine("Wrong format!");
                                }
                            }
                            Main2();
                            break;

                        case (2):
                            if(eventService.Events.Count == 0)
                            {
                                Console.WriteLine("There are no events");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < eventService.Events.Count; i++)
                            {
                                Console.WriteLine(i + ". "+  eventService.Events[i].EventName);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which event would you like to remove?");
                            int EvntRmSelection = Convert.ToInt32(Console.ReadLine());
                            eventService.Events.RemoveAt(EvntRmSelection);
                            Console.WriteLine(eventService.Events.Count);
                            Main2();
                            break;
                        case (3):
                            for( int i = 0; i < eventService.Events.Count; i++)
                            {
                                Console.WriteLine( eventService.Events[i].EventName);
                                Console.WriteLine("On " + eventService.Events[i].Date);
                                Console.WriteLine("");
                            }
                            if(eventService.Events.Count == 0)
                            {
                                Console.WriteLine("There are no events");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            Main2();
                            break;
                        case (4):
                            while(true)
                            {
                                try
                                {
                                    Console.WriteLine("Enter employee's name");
                                    string EmplName = Console.ReadLine();
                                    Console.WriteLine("Enter employee's phone number");
                                    long EmplPhoneNum = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Enter employee's Email");
                                    string EmplEMail = Console.ReadLine();
                                    Console.WriteLine("Enter employee's job title");
                                    string EmplPosition = Console.ReadLine();
                                    employeeList.AddEmployee(EmplName, EmplPhoneNum, EmplEMail, EmplPosition);
                                    break;
                                }
                                catch(FormatException e)
                                {
                                    Console.WriteLine("Wrong format!");
                                }
                            }
                            Main2();
                            break;
                        case (5):
                            if(employeeList.EmployeeCount == 0)
                            {
                                Console.WriteLine("There are no employees");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < employeeList.EmployeeCount; i++)
                            {
                                Console.WriteLine(i + ". "+   employeeList.Empl[i].Name);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which employee would you like to remove?");
                            int EmplRmSelection = Convert.ToInt32(Console.ReadLine());
                            employeeList.Empl.RemoveAt(EmplRmSelection);
                            employeeList.EmployeeCount--;
                            Main2();
                            break;
                        case (6):
                            if(employeeList.EmployeeCount == 0)
                            {
                                Console.WriteLine("There are no employees");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < employeeList.EmployeeCount; i++)
                            {
                                Console.WriteLine(i + ". "+   employeeList.Empl[i].Name);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which employees info would you like to see?");
                            int EmplInfSelection = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("The phone number of " + employeeList.Empl[EmplInfSelection].Name + " is " +  employeeList.Empl[EmplInfSelection].PhoneNum);
                            Console.WriteLine("The email of " + employeeList.Empl[EmplInfSelection].Name + " is " + employeeList.Empl[EmplInfSelection].EMail);
                            Console.WriteLine("The job title of " + employeeList.Empl[EmplInfSelection].Name + " is " +  employeeList.Empl[EmplInfSelection].Position);
                            Console.WriteLine("");
                            Main2();
                            break;
                        case (7):
                            Console.WriteLine("Enter the patients name");
                            var Name = Console.ReadLine();
                            Console.WriteLine("Enter the patients email");
                            var EMail = Console.ReadLine();
                            Console.WriteLine("Enter the patients medical history");
                            var MedicalHistory = Console.ReadLine();
                            long PhoneNum;
                            string ImportantInf;
                            while(true)
                            {
                                try
                                {
                                    Console.WriteLine("Enter patients phone number");
                                    PhoneNum = Convert.ToInt64(Console.ReadLine());
                                    break;
                                }
                                catch(FormatException e)
                                {
                                    Console.WriteLine("Wrong format!");
                                }
                            }
                            while(true)
                            {
                                try
                                {
                                    Console.WriteLine("Does the patient have any special needs?");
                                    Console.WriteLine("Enter Y or N");
                                    var NeedSelect = Console.ReadLine();
                                    if(NeedSelect == "Y")
                                    {
                                        Console.WriteLine("Enter the info");
                                        ImportantInf = Console.ReadLine();
                                        break;
                                    }
                                    if(NeedSelect == "N")
                                    {
                                        ImportantInf = null;
                                        break;
                                    }
                                    
                                }
                                catch(FormatException e)
                                {
                                    Console.WriteLine("Wrong format!");
                                }
                            }
                            patientList.AddPatient(Name,  PhoneNum,  EMail, ImportantInf, MedicalHistory);

                            Main2();
                            break;
                        case (8):
                            if(patientList.PatientCount == 0)
                            {
                                Console.WriteLine("There are no patients");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < patientList.PatientCount; i++)
                            {
                                Console.WriteLine(i + ". "+   patientList.Ptn[i].Name);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which patient would you like to remove?");
                            int PtnRmSelection = Convert.ToInt32(Console.ReadLine());
                            patientList.Ptn.RemoveAt(PtnRmSelection);
                            patientList.PatientCount--;
                            Main2();
                            break;
                        case (9):
                             if(patientList.PatientCount == 0)
                            {
                                Console.WriteLine("There are no patients");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < patientList.PatientCount; i++)
                            {
                                Console.WriteLine(i + ". "+   patientList.Ptn[i].Name);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which patients info would you like to see?");
                            int PtnlInfSelection = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("The phone number of " + patientList.Ptn[PtnlInfSelection].Name + " is " + patientList.Ptn[PtnlInfSelection].PhoneNum);
                            Console.WriteLine("The email of " + patientList.Ptn[PtnlInfSelection].Name + " is " +  patientList.Ptn[PtnlInfSelection].EMail);
                            Console.WriteLine("The medical history of " + patientList.Ptn[PtnlInfSelection].Name + " is " +  patientList.Ptn[PtnlInfSelection].MedicalHistory);
                            if(patientList.Ptn[PtnlInfSelection].ImportantInf != null)
                            {
                                Console.WriteLine("The special needs of " + patientList.Ptn[PtnlInfSelection].Name + " are " +  patientList.Ptn[PtnlInfSelection].ImportantInf);
                            }
                            Console.WriteLine("");
                            Main2();
                            break;
                        case (10):
                            string serializedEvents = eventService.SerializeEvents();
                            Console.WriteLine(serializedEvents);
                            try
                            {
                                StreamWriter sw = new StreamWriter("Sample.txt");
                                sw.WriteLine(serializedEvents);
                                sw.Close();
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Executing finally block.");
                            }
                            break;
                        case (11):
                            eventService.DeserializeEvents();                            
                            break;
                        case (12):
                            break;   
                        default:
                            Console.WriteLine("None selected");
                            break;

                    }
                }
            }
        }
}
