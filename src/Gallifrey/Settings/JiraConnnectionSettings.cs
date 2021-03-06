﻿using Gallifrey.Serialization;

namespace Gallifrey.Settings
{
    public interface IJiraConnectionSettings
    {
        string JiraUrl { get; set; }
        string JiraUsername { get; set; }
        string JiraPassword { get; set; }
    }

    public class JiraConnectionSettings : IJiraConnectionSettings
    {
        public string JiraUrl { get; set; }
        public string JiraUsername { get; set; }
        public string JiraPassword { get; set; }

        internal void SaveSettings()
        {
            JiraConnectionSettingsSerializer.Serialize(this);    
        }
    }
}
