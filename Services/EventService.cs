using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.SQLite;
using System.IO;


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

        public List<CalendarEvent> DeserializeEvents()
        {
            string content = File.ReadAllText("Sample.txt");
            var deserializedEvents = JsonSerializer.Deserialize<List<CalendarEvent>>(content);
            return deserializedEvents;
        }

        public void DataBase()
        {
            
            string cs = @"Data Source=C:\Users\mykol\Documents\GitHub\sqlite-tools-win32-x86-3330000\test.db";
            string stm = "SELECT SQLITE_VERSION()";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");

            using var cmd1 = new SQLiteCommand(con);

            cmd1.CommandText = "DROP TABLE IF EXISTS cars";
            cmd1.ExecuteNonQuery();

            cmd1.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY, name TEXT, price INT)";
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            cmd1.ExecuteNonQuery();

            cmd1.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
            cmd1.ExecuteNonQuery();
        }

    }
     public class CalendarEvent
    {
        public string EventName {get; set;}  
        public DateTime Date {get; set;}      
    }

    
}
