using System;
using System.Collections.Generic;

namespace mainSys
    {
        public class Calendar
        {
            
            public int EventCount;
            public IList<CalendarEvent> Events = new List<CalendarEvent>();
            public void AddEvent()
            {
                var newEvent = new CalendarEvent();
                
                Console.WriteLine("Enter event name...");
                newEvent.EventName =  Console.ReadLine();
                Console.WriteLine("Enter year...");
                int Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month(number)...");
                int Month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day...");
                int Day = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter hour...");
                int Hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter minute...");
                int Minute = Convert.ToInt32(Console.ReadLine());
                int Second = 00;
                newEvent.Date = new DateTime(Year, Month, Day, Hour,  Minute, Second);
                this.Events.Add(newEvent);
                EventCount ++;
            }
        }
        public class CalendarEvent
        {
            public  string EventName;
            public DateTime Date;

            
        }
        public class EmployeeList
        {
            public int  EmployeeCount;
            public IList<EmployeeInf> Empl = new List<EmployeeInf>();
            public void AddEmployee()
            {
                var newEmpl = new EmployeeInf();
                Console.WriteLine("Enter employee name");
                newEmpl.Name = Console.ReadLine();
                Console.WriteLine("Enter employee phone number");
                newEmpl.PhoneNum = Console.ReadLine();
                Console.WriteLine("Enter employee Email");
                newEmpl.EMail = Console.ReadLine();
                Console.WriteLine("Enter employee job title");
                newEmpl.Position = Console.ReadLine();
                this.Empl.Add(newEmpl);
                EmployeeCount ++;
            }
        }
        public class EmployeeInf
        {
            public string Name;
            public string PhoneNum;
            public string EMail;
            public string Position; 
            
        }
        public class PatientsList
        {
            public IList<PatientsInf> Ptn = new List<PatientsInf>();
            public int PatientCount;

            public void AddPatient()
            {
                var newPtn = new PatientsInf();
                Console.WriteLine("Enter the patients name");
                newPtn.Name = Console.ReadLine();
                Console.WriteLine("Enter the patients phone number");
                newPtn.PhoneNum = Console.ReadLine();
                Console.WriteLine("Enter the pacients email");
                newPtn.EMail = Console.ReadLine();
                Console.WriteLine("Does the pacient have any special conditions");
                Console.WriteLine("Y/N");
                newPtn.SpecialNd = Console.ReadLine();
                switch (newPtn.SpecialNd)
                {
                    case ("Y"):
                        if(newPtn.SpecialNd != "Y" && newPtn.SpecialNd != "N")
                        {
                            newPtn.SpecialNd = Console.ReadLine();
                            goto default;
                        }
                        else if(newPtn.SpecialNd == "N")
                        {
                            goto case "N";
                        }
                        Console.WriteLine("Enter the info");
                        newPtn.ImportantInf = Console.ReadLine();
                        break;
                    case ("N"):
                        break;
                    default:
                        Console.WriteLine("Invalid character!");
                        Console.WriteLine("Enter Y or N");
                        goto case "Y";
                }
                Console.WriteLine("Enter the patients medical history");
                newPtn.MedicalHistory = Console.ReadLine();
                this.Ptn.Add(newPtn);
                PatientCount++;


            }
        }

        public class PatientsInf
        {
            public string SpecialNd;
            public string Name;
            public string PhoneNum;
            public string EMail;
            public string ImportantInf;
            public string MedicalHistory;
        }

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
                var calendar = new Calendar();
                var employeeList = new EmployeeList();
                var patientList = new PatientsList();
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
                    Console.WriteLine("Enter 10 to exit program");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection)
                    {
                        case (1):
                            calendar.AddEvent();
                            Console.WriteLine("You have added the event " + calendar.Events[calendar.EventCount - 1].EventName + " on " + calendar.Events[calendar.EventCount - 1].Date);
                            Main2();
                            break;
                        case (2):
                            if(calendar.EventCount == 0)
                            {
                                Console.WriteLine("There are no events");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            for( int i = 0; i < calendar.EventCount; i++)
                            {
                                Console.WriteLine(i + ". "+  calendar.Events[i].EventName);
                                Console.WriteLine("On " + calendar.Events[i].Date);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Which event would you like to remove?");
                            int EvntRmSelection = Convert.ToInt32(Console.ReadLine());
                            calendar.Events.RemoveAt(EvntRmSelection);
                            calendar.EventCount--;
                            Console.WriteLine(calendar.EventCount);
                            Main2();
                            break;
                        case (3):
                            for( int i = 0; i < calendar.EventCount; i++)
                            {
                                Console.WriteLine( calendar.Events[i].EventName);
                                Console.WriteLine("On " + calendar.Events[i].Date);
                                Console.WriteLine("");
                            }
                            if(calendar.EventCount == 0)
                            {
                                Console.WriteLine("There are no events");
                                Console.WriteLine("");
                                Main2();
                                break;
                            }
                            Main2();
                            break;
                        case (4):
                            employeeList.AddEmployee();
                            Console.WriteLine("You have added the employee " + employeeList.Empl[employeeList.EmployeeCount - 1].Name + " whose position is " + employeeList.Empl[employeeList.EmployeeCount - 1].Position);
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
                            patientList.AddPatient();
                            Console.WriteLine("You have added the patient " + patientList.Ptn[patientList.PatientCount - 1].Name);
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
                            if( patientList.Ptn[PtnlInfSelection].SpecialNd == "Y")
                            {
                                Console.WriteLine("The important info of " + patientList.Ptn[PtnlInfSelection].Name + " is " +  patientList.Ptn[PtnlInfSelection].ImportantInf);
                            }
                            Console.WriteLine("The medical history of " + patientList.Ptn[PtnlInfSelection].Name + " is " +  patientList.Ptn[PtnlInfSelection].MedicalHistory);
                            Console.WriteLine("");
                            Main2();
                            break;
                        case (10):

                            break;   
                        default:
                            Console.WriteLine("None selected");
                            break;

                    }
                }
            }
        }
}
