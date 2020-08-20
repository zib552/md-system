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

        public class Pacients
        {
            string name;
            string phoneNum;
            string eMail;
            string allergies;
            string medicalHistory;
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
                Main2();
                void Main2(){
                    Console.WriteLine("Enter 1 to add a new event");
                    Console.WriteLine("Enter 2 to remove  an event");
                    Console.WriteLine("Enter 3 to view all events");
                    Console.WriteLine("Enter 4 to add a new employee");
                    Console.WriteLine("Enter 5 to remove an employee");
                    Console.WriteLine("Enter 6 to view employee info");
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
