namespace AppSecrect.CrossCutting.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DbConnectionStrng { get; set; }
        public string DbPort { get; set; }
        public string DbDataBaseName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public string DbUri { get; set; }
        public string Connection { get; set; }
    }
}
