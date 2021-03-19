using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
using MEC;

namespace _079Evolution
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public static bool Coold = true;
        public static bool Cooldw = true;


        // cooldown de habilidad
        public static IEnumerator<float> Cooldown0792(Player player)
        {

            yield return Timing.WaitForSeconds(60f);
            Coold = true;

        }
        public static IEnumerator<float> Cooldown0793(Player player)
        {

            yield return Timing.WaitForSeconds(120f);
            Cooldw = true;
        }

        internal void OnRolChange(ChangingRoleEventArgs ev)
        {
            if(ev.NewRole == RoleType.Scp079)
            {
                ev.Player.Broadcast(5, "<color=yellow>Ahora como SCP-079 tienes comandos! para mirarlos, solo usa la consola del juego (ñ). Ahí tendras la lista de comandos que puedes usar.</color>");
                ev.Player.SendConsoleMessage("Ayuda", "yellow");
                ev.Player.SendConsoleMessage(".079 help/? muestra este mensaje", "yellow");
                ev.Player.SendConsoleMessage(".079 suicide te lleva al expectador (solo si no quedan SCPs)", "yellow");
                ev.Player.SendConsoleMessage(".079 chaos manda un mensaje fake del cassie (spawn de chaos) (Nivel 2 Energia 60) Cooldown: 60sec", "yellow");
                ev.Player.SendConsoleMessage(".079 mtf manda un mensaje fake del cassie (spawn de mtf) (Nivel 2 Energia 60) Cooldown: 60sec", "yellow");
                ev.Player.SendConsoleMessage(".079 blackout apaga las luces de todas las instalaciones durante 8 segundos (Nivel 3 Energia 100) Cooldown: 120sec", "yellow");
            }
        }
        
    }
}
