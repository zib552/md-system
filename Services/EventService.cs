﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Services
{
    public class EventService
    {
        public IList<CalendarEvent> Events = new List<CalendarEvent>();

        
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
            return newEvent;
        }

        
        public string SerializeEvents()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var serializedEvents = JsonSerializer.Serialize(this.Events, options);
            return serializedEvents;

        }
// ISAVINTI VISKA I FILE
// ANT STARTUP PERSKAITYTU FAILA

    }

     public class CalendarEvent
    {
        public string EventName {get; set;}  
        public DateTime Date {get; set;}      
    }
}
