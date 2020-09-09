using System;
using System.Collections.Generic;

    namespace Patients
    {
        public class PatientsList
        {
            public IList<PatientsInf> Ptn = new List<PatientsInf>();
            public int PatientCount;

            public void AddPatient(string Name, long PhoneNum, string EMail, string ImportantInf, string MedicalHistory)
            {
                var newPtn = new PatientsInf();
                newPtn.Name = Name;
                newPtn.PhoneNum = PhoneNum;
                newPtn.EMail = EMail;
                newPtn.ImportantInf = ImportantInf;
                newPtn.MedicalHistory = MedicalHistory;
                this.Ptn.Add(newPtn);
                PatientCount++;


            }
        }

        public class PatientsInf
        {
            public string Name;
            public long PhoneNum;
            public string EMail;
            public string ImportantInf;
            public string MedicalHistory;
        }
    }