﻿using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _079Evolution.Commands.SubCommands;
using Exiled.API.Features;

namespace _079Evolution.Commands
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Parent : ParentCommand
    {
        public Parent() => LoadGeneratedCommands();
        public override string Command { get; } = "079";
        public override string[] Aliases { get; } = { "zsn" };
        public override string Description { get; } = "079 Parent command";
        

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Suicide());
            RegisterCommand(new Mtf());
            RegisterCommand(new Blackout());
            RegisterCommand(new Chaos());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Plugin.plugin.Config.BadCommandMsg;
            return false;
        }
    }
}
