using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using MEC;

namespace _079Evolution.Commands.SubCommands
{
    class Blackout : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((CommandSender)sender);
            //Role, cooldown & Level/Energy Check
            if (player.Role != RoleType.Scp079) { response = "No puedes usar este comando si no eres SCP-079"; return false; }
            if (!EventHandlers.Cooldw) { response = "Habilidad en cooldown"; return false; }
            //if (ev.Player.Energy < 100 || ev.Player.Level < 3) { ev.ReturnMessage = "Necesitas Tier 3 y 100 de energia para usar este comando"; return; }
            if(player.Level < 2) { response = "Necesitas ser Tier 3 para usar este comando"; return false;  }
            if(player.Energy < 100) { response = "Necesitas 100 de energia para usar este comando"; return false; }
            //Response
            response = Plugin.plugin.Config.BlackoutMsg;
            //Event
            EventHandlers.Cooldw = false;
            Cassie.Message("pitch_0.5 .g3 .g3 .g3 pitch_1 Danger . SCP 0 7 9 Will turn off the light system in 3 . 2 . 1 ");
            Timing.CallDelayed(13f, () => { Map.TurnOffAllLights(8f); });
            
            
            int plt = (int)System.Environment.OSVersion.Platform;
            if ((plt == 4) || (plt == 6) || (plt == 128)) Timing.RunCoroutine(EventHandlers.Cooldown0793(player), MEC.Segment.Update);
            else Timing.RunCoroutine(EventHandlers.Cooldown0793(player), 1);
            return true;
        }

        public string Command { get; } = "blackout";
        public string[] Aliases { get; } = {"bo"};
        public string Description { get; } = "Turns off the lights of all the fundation";
    }
}
