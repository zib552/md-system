using System;
using System.Collections.Generic;

namespace Services
{
    public class EventService
    {
        public IList<CalendarEvent> Events = new List<CalendarEvent>();

        public int eventCount;
        
        public  DateTime AddEvent()
        {
            return new DateTime(12, 12, 12, 12, 12, 12);
        }
        public CalendarEvent AddEventServiceDate(string newEventName, DateTime date)
        {
            var newEvent = new CalendarEvent();
            newEvent.EventName = newEventName;
            newEvent.Date = date;
            this.Events.Add(newEvent);
            eventCount++;
            return newEvent;
        }


    }

     public class CalendarEvent
    {
        public  string EventName;
        public DateTime Date;         
    }
}
