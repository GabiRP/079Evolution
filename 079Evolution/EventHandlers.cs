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


        // cooldown de habilidad
        public static IEnumerator<float> Cooldown0792(Player player)
        {

            yield return Timing.WaitForSeconds(60f);
            Coold = true;

        }
        public static IEnumerator<float> Cooldown0793(Player player)
        {

            yield return Timing.WaitForSeconds(120f);
            Cooldw = true;
        }

        internal void OnRolChange(ChangingRoleEventArgs ev)
        {
            if(ev.NewRole == RoleType.Scp079)
            {
                ev.Player.Broadcast(plugin.Config.BroadcastDuration, plugin.Config.SpawnBroadcast);
                ev.Player.SendConsoleMessage(ev.Player, plugin.Config.SpawnCmdMsg, "yellow");
            }
        }

        internal void OnSpawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
            {
                Cassie.Message("pitch_0.5 .g3 .g3 . pitch_1 Danger . Danger . Unauthorized access detected at surface Gate A . All security units report to Entrance Zone in order to stop the intruders pitch_0.5 .g3");
            }
        }
        
    }
}
