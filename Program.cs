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
                Console.WriteLine("Enter seconds...");
                int Second = Convert.ToInt32(Console.ReadLine());
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

        public class Employes
        {
            string name;
            string phoneNum;
            string eMail;
            string status;
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
                Main2();
                void Main2(){
                    Console.WriteLine("Enter 1 to add a new event");
                    Console.WriteLine("Enter 2 to remove  an event");
                    Console.WriteLine("Enter 3 to view all events");
                    Console.WriteLine("Enter 10 to exit program");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection)
                    {
                        case (1):
                            calendar.AddEvent();
                            Console.WriteLine("You have added the event " + calendar.Events[0].EventName + " on " + calendar.Events[0].Date);
                            Main2();
                            break;
                        case (2):
                            for( int i = 0; i < calendar.EventCount; i++)
                            {
                                Console.WriteLine(i + ". "+  calendar.Events[i].EventName);
                                Console.WriteLine("On " + calendar.Events[i].Date);
                            }
                            Console.WriteLine("Which event would you like to remove?");
                            int RmSelection = Convert.ToInt32(Console.ReadLine());
                            calendar.Events.RemoveAt(RmSelection);
                            calendar.EventCount--;
                            Console.WriteLine(calendar.EventCount);
                            Main2();
                            break;
                        case (3):
                            for( int i = 0; i < calendar.EventCount; i++)
                            {
                                Console.WriteLine( calendar.Events[i].EventName);
                                Console.WriteLine("On " + calendar.Events[i].Date);
                            }
                            if(calendar.EventCount == 0)
                            {
                                Console.WriteLine("There are no events");
                            }
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

