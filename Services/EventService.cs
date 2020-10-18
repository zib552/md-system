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
            string content = File.ReadAllText("../Sample.txt");
            var deserializedEvents = JsonSerializer.Deserialize<List<CalendarEvent>>(content);
            return deserializedEvents;
        }

        public void DataBase(IList<CalendarEvent> Events)
        {
            Console.WriteLine("DO YOU WANT TO ADD NEW EVENT OR UPDATE CURRENT EVENT");
            Console.WriteLine("1. ADD NEW EVENT 2. UPDATE CURRENT EVENT");
            int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection){
                        case (1):{        

                            string cs = @"Data Source=C:\Users\mykol\Documents\GitHub\sqlite-tools-win32-x86-3330000\test.db";
                            string stm = "SELECT SQLITE_VERSION()";

                            using var con = new SQLiteConnection(cs);
                            con.Open();

                            using var cmd = new SQLiteCommand(stm, con);
                            string version = cmd.ExecuteScalar().ToString();

                            using var cmd1 = new SQLiteCommand(con);

                            cmd1.CommandText = "SELECT COUNT(name) FROM events";
                            var count = cmd1.ExecuteScalar();
                            var count1 = Convert.ToInt32(count);
                            
                            //cmd1.CommandText = "DROP TABLE IF EXISTS events";
                            //cmd1.ExecuteNonQuery();

                            //cmd1.CommandText = @"CREATE TABLE events(id INTEGER PRIMARY KEY, name TEXT, date DATE)";
                            //cmd1.ExecuteNonQuery();
                        
                            Console.WriteLine(count1);
                            for(var i = 0; i < Events.Count; i++){

                                var name = Events[i].EventName;
                                var date = Events[i].Date.ToString();
                                cmd1.CommandText =$"SELECT COUNT(*) FROM events WHERE name = '{name}' AND date = '{date}'";
                                var ex = cmd1.ExecuteScalar();
                                var ex1 = Convert.ToInt32(ex);
                                if (ex1 == 0)
                                {
                                    cmd1.CommandText = $"INSERT INTO events(name, date) VALUES('{name}','{date}')";
                                    cmd1.ExecuteNonQuery();
                                }
                            }
                            break;
                        }
                        case (2):
                        {
                            string cs = @"Data Source=C:\Users\mykol\Documents\GitHub\sqlite-tools-win32-x86-3330000\test.db";
                                string stm = "SELECT SQLITE_VERSION()";

                                using var con = new SQLiteConnection(cs);
                                con.Open();

                                using var cmd = new SQLiteCommand(stm, con);
                                string version = cmd.ExecuteScalar().ToString();

                                using var cmd1 = new SQLiteCommand(con);

                                cmd1.CommandText = "UPDATE events SET name = 'TEST301' WHERE name = 'TEST 30'";
                                cmd1.ExecuteNonQuery();

                                
                                break;
                        }    
                        default:
                           break;

                    


        }

    }
        public class CalendarEvent
        {
            public string EventName {get; set;}  
            public DateTime Date {get; set;}      
        }
    }
}

