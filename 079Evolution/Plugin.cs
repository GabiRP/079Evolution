using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

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
