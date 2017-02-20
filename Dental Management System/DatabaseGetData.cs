using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dental_Management_System
{
    class DatabaseGetData
    {
        public string getDataFromDatabase = "SELECT patient_information.PID, patient_information.FirstName, patient_information.MiddleName, patient_information.LastName, patient_information.Birthday, patient_information.Gender, patient_information.PhoneNumber, patient_information.Email FROM patient_information";
    }
}
