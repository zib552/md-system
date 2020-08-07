using System;

    namespace mainSys
    {
        public class calendar
        {
            int eventCount;
            public static void addEvent()
            {
                
                Console.WriteLine("Enter event name...");
                calendarEvent.eventName =  Console.ReadLine();
                Console.WriteLine("Enter hour...");
                calendarEvent.hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter minute...");
                calendarEvent.minute = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day...");
                calendarEvent.day = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month(number)...");
                calendarEvent.month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter year...");
                calendarEvent.year = Convert.ToInt32(Console.ReadLine());
            }
        }
        public class calendarEvent
        {
            public static int year;
            public static int month;
            public static int day;
            public static int hour;
            public static int minute;
            public static string eventName;

            
        }

        public class employes
        {
            string name;
            string phoneNum;
            string eMail;
            string status;
        }

        public class pacients
        {
            string name;
            string phoneNum;
            string eMail;
            string allergies;
            string medicalHistory;
        }

        public class msg
        {
            string content;
            string recipient;
            string sender;
        }

        class program
        {
            static void Main()
            {
                calendar.addEvent();
                Console.WriteLine("You have added the event " + calendarEvent.eventName + " on " + calendarEvent.hour + ":" + calendarEvent.minute + " " + calendarEvent.day + "/" + calendarEvent.month + "/" + calendarEvent.year );
                
            }
        }
}

