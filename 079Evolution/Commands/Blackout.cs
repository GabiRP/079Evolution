using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using MEC;

namespace _079Evolution.Commands
{
    public class Blackout : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Debug("Blackout command executed", Plugin.plugin.Config.DebugEnabled);
            
            Player player = Player.Get((CommandSender)sender);
            //Role, cooldown & Level/Energy Check
            if (player.Role != RoleType.Scp079) { response = Plugin.plugin.Config.Translations.NoRole; return false; }
            if (!EventHandlers.Cooldw) { response = Plugin.plugin.Config.Translations.Cooldown; return false; }
            //if (ev.Player.Energy < 100 || ev.Player.Level < 3) { ev.ReturnMessage = "Necesitas Tier 3 y 100 de energia para usar este comando"; return; }
            if(player.Level < 2) { response = Plugin.plugin.Config.Translations.LvlEnergyMsg; return false;  }
            if(player.Energy < 100) { response = Plugin.plugin.Config.Translations.LvlEnergyMsg; return false; }
            //Response
            response = Plugin.plugin.Config.Translations.BlackoutMsg;
            //Event
            player.Energy -= 100;
            EventHandlers.Cooldw = false;
            Log.Debug("Running Blackout coroutine", Plugin.plugin.Config.DebugEnabled);
            Timing.RunCoroutine(BOut());
            
            
            int plt = (int)System.Environment.OSVersion.Platform;
            if ((plt == 4) || (plt == 6) || (plt == 128)) Timing.RunCoroutine(EventHandlers.Cooldown0793(), MEC.Segment.Update);
            else Timing.RunCoroutine(EventHandlers.Cooldown0793(), 1);
            return true;
        }

        private IEnumerator<float> BOut()
        {
            Cassie.Message(Plugin.plugin.Config.BlackoutCassie);
            yield return Timing.WaitForSeconds(13f);
            Map.TurnOffAllLights(Plugin.plugin.Config.BlackoutTime);
        }
        public string Command { get; } = "blackout";
        public string[] Aliases { get; } = {"bo"};
        public string Description { get; } = "Turns off the lights of all the fundation";
    }
}
