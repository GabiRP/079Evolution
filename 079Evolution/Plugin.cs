using Exiled.API.Features;
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
            plugin = this;
            EventHandlers = new EventHandlers(this);
            Player.ChangingRole += EventHandlers.OnRolChange;
            Server.RespawningTeam += EventHandlers.OnSpawningTeam;

        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            
            Player.ChangingRole -= EventHandlers.OnRolChange;
            Server.RespawningTeam -= EventHandlers.OnSpawningTeam;
            EventHandlers = null;
            plugin = null;
        }
    }
}
