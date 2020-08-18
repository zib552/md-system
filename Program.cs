using System;
using System.Collections.Generic;

namespace mainSys
    {
        public class Calendar
        {
            
            int eventCount;
            public IList<CalendarEvent> Events = new List<CalendarEvent>();
            public void AddEvent()
            {
                var newEvent = new CalendarEvent();
                Console.WriteLine("Enter event name...");
                newEvent.eventName =  Console.ReadLine();
                Console.WriteLine("Enter hour...");
                newEvent.hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter minute...");
                newEvent.minute = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day...");
                newEvent.day = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month(number)...");
                newEvent.month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter year...");
                newEvent.year = Convert.ToInt32(Console.ReadLine());
                this.Events.Add(newEvent); 
            }
        }
        public class CalendarEvent
        {
            public  int year;
            public  int month;
            public  int day;
            public  int hour;
            public  int minute;
            public  string eventName;
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
                calendar.AddEvent();
                Console.WriteLine("You have added the event " + calendar.Events[0].eventName + " on " + calendar.Events[0].hour + ":" +calendar.Events[0].minute + " " + calendar.Events[0].day + "/" + calendar.Events[0].month + "/" +calendar.Events[0].year );
                
            }
        }
}

