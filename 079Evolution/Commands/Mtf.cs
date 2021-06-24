using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;

namespace _079Evolution.Commands
{
    public class Mtf : ICommand
    {
        public string Command { get; } = "mtf";

        public string[] Aliases { get; } = {"mtf"};

        public string Description { get; } = "Turns SCP-079 into a spectator";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Debug("Mtf fakespawn command executed", Plugin.plugin.Config.DebugEnabled);
            Player player = Player.Get((CommandSender) sender);
            if (player.Role != RoleType.Scp079)
            {
                response = Plugin.plugin.Config.Translations.NoRole;
                return false;
            }
            if (player.Role != RoleType.Scp079) { response = "No puedes usar este comando si no eres SCP-079"; return false; }
            if (!EventHandlers.Coold) { response = Plugin.plugin.Config.Translations.Cooldown; return false; }
            if (player.Level < 1) { response = Plugin.plugin.Config.Translations.LvlEnergyMsg; return false; }
            if (player.Energy < 60) { response = Plugin.plugin.Config.Translations.LvlEnergyMsg; return false; }
            
            Cassie.Message(Plugin.plugin.Config.MtfCassie);
            player.Energy -= 60;
            EventHandlers.Coold = false;
            int p = (int)System.Environment.OSVersion.Platform;
            if ((p == 4) || (p == 6) || (p == 128)) MEC.Timing.RunCoroutine(EventHandlers.Cooldown0792(), MEC.Segment.Update);
            else MEC.Timing.RunCoroutine(EventHandlers.Cooldown0792(), 1);
            response = Plugin.plugin.Config.Translations.MtfMsg;
            return true;
        }
    }
}
