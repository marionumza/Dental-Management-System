using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dental_Management_System
{
    class DatabaseConnectionLink
    {
        public string networkLink = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + "Database=" +
        Properties.Settings.Default["SQL_Database"] + ";" + "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
        Properties.Settings.Default["SQL_Pass"];

        public string networkLinkDatabaseList = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' + 
        "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
        Properties.Settings.Default["SQL_Pass"];

        public string networkTestLink = "Server=" + Properties.Settings.Default["SQL_IP"] + ';'
        + "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" + Properties.Settings.Default["SQL_Pass"];

        public string networkLinkCreateDatabase = "Server=" + Properties.Settings.Default["SQL_IP"] + ';' +
                "UID=" + Properties.Settings.Default["SQL_User"] + ';' + "PWD=" +
                Properties.Settings.Default["SQL_Pass"];
    }
}
