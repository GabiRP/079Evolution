using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _079Evolution
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("SpawnBroadcast duration")]
        public ushort BroadcastDuration { get; set; } = 5;

        [Description("How many seconds should the facility be during the blackout")]
        public float BlackoutTime { get; set; } = 10f;

        [Description("Plugin translations")] 
        public Translations PluginTranslations = new Translations();

    }
}
