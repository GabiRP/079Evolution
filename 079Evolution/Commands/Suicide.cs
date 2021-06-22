﻿using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;

namespace _079Evolution.Commands
{
    public class Suicide : ICommand
    {
        public string Command { get; } = "suicide";

        public string[] Aliases { get; } = {"suicide"};

        public string Description { get; } = "Turns SCP-079 into a spectator";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((CommandSender)sender);
            if (ply.Role != RoleType.Scp079)
            {
                response = Plugin.plugin.Config.PluginTranslations.NoRole;
                return false;
            }
            IEnumerable<Player> enumerable = Player.List.Where(x => x.Team == Team.SCP);
            List<Player> pList = enumerable.ToList();
            if (pList.Count == 1 && pList[0].Role == RoleType.Scp079)
            {
                Player player = pList[0];
                player.SetRole(RoleType.Spectator);
                response = Plugin.plugin.Config.PluginTranslations.SuicideMsg;
                return true;
            }

            response = "Todavía quedan otros SCPs";
            return false;

        }
    }
}
