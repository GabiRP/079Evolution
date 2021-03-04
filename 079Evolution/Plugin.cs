using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace _079Evolution
{
    public class Plugin : Plugin<Config>
    {
        public Plugin plugin;
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers(this);
            Server.SendingConsoleCommand += EventHandlers.OnConsoleCommand;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Server.SendingConsoleCommand -= EventHandlers.OnConsoleCommand;
            EventHandlers = null;
        }
    }
}
