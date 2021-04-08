using Exiled.API.Features;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using MEC;

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
                ev.Player.SendConsoleMessage(ev.Player, plugin.Config.SpawnCmdMsg, plugin.Config.CmdColor);
            }
        }
        
    }
}
