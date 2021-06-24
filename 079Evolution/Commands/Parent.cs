using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem.Commands;
using Exiled.API.Features;

namespace _079Evolution.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Parent : ParentCommand
    {
        
        public override string Command { get; } = "079";
        public override string[] Aliases { get; } = { "zsn" };
        public override string Description { get; } = "079 Parent command";
        public Parent() => LoadGeneratedCommands();

        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new Suicide());
            RegisterCommand(new Mtf());
            RegisterCommand(new Blackout());
            RegisterCommand(new Chaos());
            RegisterCommand(new Help());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Plugin.plugin.Config.Translations.CmdMsg;
            return false;
        }
    }

    public class Help : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(sender as CommandSender);
            if (ply.Role == RoleType.Scp079)
            {
                Log.Debug("Sending help message to player", Plugin.plugin.Config.DebugEnabled);
                response = Plugin.plugin.Config.Translations.CmdMsg;
                return true;
            }
            Log.Debug("Player is not SCP-079, sending error message", Plugin.plugin.Config.DebugEnabled);
            response = Plugin.plugin.Config.Translations.NoRole;
            return false;
        }

        public string Command { get; } = "help";
        public string[] Aliases { get; } = {"?"};
        public string Description { get; } = "Help command";
    }
}
