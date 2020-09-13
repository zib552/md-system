using System.IO;
using System;

    namespace Services

    {
        public class FileService
        {
            public void WriteFile()
            {

            }

            public string ReadFile()
            {
                try
                {             
                    StreamReader sr = new StreamReader(".\\Sample.txt");
                    var content = sr.ReadToEnd();
                    sr.Close();
                    return content;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    return null;
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

            }

        }

    }