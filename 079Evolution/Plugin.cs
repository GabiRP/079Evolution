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
        public static Plugin plugin;
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers(this);
            Player.ChangingRole += EventHandlers.OnRolChange;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Player.ChangingRole -= EventHandlers.OnRolChange;
            EventHandlers = null;
        }
    }
}
