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

        [Description("Is debug enabled?")] 
        public bool DebugEnabled { get; set; } = false;
        
        [Description("SpawnBroadcast duration")]
        public ushort BroadcastDuration { get; set; } = 5;

        [Description("How many seconds should the facility be during the blackout")]
        public float BlackoutTime { get; set; } = 10f;

        [Description("Cassie for Mtf fake respawn")]
        public string MtfCassie { get; set; } =
            "MtfUnit Epsilon 11 designated nato_a 5 hasentered allremaining awaitingrecontainment UncalculatedSCPsLeft";
        [Description("Cassie for Chaos fake spawn, and chaos spawning event if true")]
        public string ChaosCassie { get; set; } =
            "pitch_0.5 .g3 .g3 . pitch_1 Danger . Danger . Unauthorized access detected at surface Gate A . All security units report to Entrance Zone in order to stop the intruders pitch_0.5 .g3";

        [Description("Do you want a chaos spawning cassie?")]
        public bool ChaosSpawnCassie { get; set; } = true;

        [Description("Plugin translations")] 
        public Translations PluginTranslations = new Translations();

    }
}
