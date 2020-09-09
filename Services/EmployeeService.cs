using System;
using System.Collections.Generic;

    namespace Employees
    {
        public class EmployeeList
        {
            public int  EmployeeCount;
            public IList<EmployeeInf> Empl = new List<EmployeeInf>();
            public void AddEmployee(string Name, long PhoneNum, string EMail, string Position)
            {
                var newEmpl = new EmployeeInf();
                newEmpl.Name = Name;
                newEmpl.PhoneNum = PhoneNum;
                newEmpl.EMail = EMail;
                newEmpl.Position = Position;
                this.Empl.Add(newEmpl);
                EmployeeCount ++;
            }
        }

        public class EmployeeInf
        {
            public string Name;
            public long PhoneNum;
            public string EMail;
            public string Position; 
            
        }
    }