using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dental_Management_System
{
    class DatabaseGetData
    {
        public string getDataFromDatabase = "SELECT patient_information.PID, patient_information.FirstName, patient_information.MiddleName, patient_information.LastName, patient_information.Birthday, patient_information.Gender, patient_information.PhoneNumber, patient_information.Email FROM patient_information";

        public string getScheduleDataFromDatabase = "SELECT patient_schedule.ID, patient_schedule.Time, patient_schedule.Date, patient_schedule.LastName, patient_schedule.FirstName FROM patient_schedule";

        public string getDentalClincFromDatabase = "SELECT dental_services.ServiceName, dental_services.Fee from dental_services";

        public string getALLDentalClinicFromDatabase = "SELECT * from dental_services";

        public string getUserAccounts = "SELECT UserAccounts.ID, UserAccounts.UserName, UserAccounts.AccountType FROM UserAccounts";
    }
}
