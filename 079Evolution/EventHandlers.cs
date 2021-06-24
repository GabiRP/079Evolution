using Exiled.API.Features;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using MEC;
using Respawning;

namespace _079Evolution
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public static bool Coold = true;
        public static bool Cooldw = true;


       
        public static IEnumerator<float> Cooldown0792()
        {
            yield return Timing.WaitForSeconds(60f);
            Coold = true;

        }
        public static IEnumerator<float> Cooldown0793()
        {

            yield return Timing.WaitForSeconds(120f);
            Cooldw = true;
        }

        internal void OnRolChange(ChangingRoleEventArgs ev)
        {
            if(ev.NewRole == RoleType.Scp079)
            {
                Log.Debug("Sending Broadcast and Console message to SCP-079", plugin.Config.DebugEnabled); 
                ev.Player.Broadcast(plugin.Config.BroadcastDuration, plugin.Config.Translations.SpawnBroadcast);
                ev.Player.SendConsoleMessage(ev.Player, plugin.Config.Translations.CmdMsg, "yellow");
            }
        }

        internal void OnSpawningTeam(RespawningTeamEventArgs ev)
        {
            if (!plugin.Config.ChaosSpawnCassie)
            {
                Log.Debug("Chaos spawn cassie is not enabled, returning", plugin.Config.DebugEnabled); 
                return;
            }
            if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
            {
                Log.Debug("Chaos spawn cassie is enabled, sending message", plugin.Config.DebugEnabled); 
                Cassie.Message(plugin.Config.ChaosCassie);
            }
        }
        
    }
}
