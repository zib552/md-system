using System;
using System.Collections.Generic;

namespace Services
{
    public class EventService
    {
        public IList<CalendarEvent> Events = new List<CalendarEvent>();
        
        public  DateTime AddEvent()
        {
            return new DateTime(12, 12, 12, 12, 12, 12);
        }
        public CalendarEvent AddEventService(string newEventName, DateTime date)
        {
            var newEvent = new CalendarEvent();
            newEvent.EventName = newEventName;
            newEvent.Date = date;
            this.Events.Add(newEvent);
            return newEvent;
        }


    }

     public class CalendarEvent
    {
        public  string EventName;
        public DateTime Date;         
    }
}
