﻿using System;
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
            Player player = Player.Get((CommandSender) sender);
            if (player.Role != RoleType.Scp079)
            {
                response = Plugin.plugin.Config.PluginTranslations.NoRole;
                return false;
            }
            if (player.Role != RoleType.Scp079) { response = "No puedes usar este comando si no eres SCP-079"; return false; }
            if (!EventHandlers.Cooldw) { response = Plugin.plugin.Config.PluginTranslations.Cooldown; return false; }
            if (player.Level < 1) { response = "Necesitas ser Tier 2 para usar este comando"; return false; }
            if (player.Energy < 60) { response = "Necesitas 60 de energia para usar este comando"; return false; }
            
            Cassie.Message("pitch_0.3 .g3 .g3 . pitch_1 MtfUnit Alpha 1 designated Red Right Hand hasentered .  O5 personnel please proceed to the helicopter . ");
            player.Energy -= 60;
            EventHandlers.Coold = false;
            int p = (int)System.Environment.OSVersion.Platform;
            if ((p == 4) || (p == 6) || (p == 128)) MEC.Timing.RunCoroutine(EventHandlers.Cooldown0792(), MEC.Segment.Update);
            else MEC.Timing.RunCoroutine(EventHandlers.Cooldown0792(), 1);
            response = Plugin.plugin.Config.PluginTranslations.MtfMsg;
            return true;
        }
    }
}
