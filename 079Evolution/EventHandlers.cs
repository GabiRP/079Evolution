using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;

namespace _079Evolution
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        static Dictionary<string, bool> Pasivaa = new Dictionary<string, bool>();


        // cooldown de habilidad
        private IEnumerator<float> Cooldown0792(Player player)
        {

            yield return MEC.Timing.WaitForSeconds(60f);
            Pasivaa[player.Id.ToString()] = true;

        }
 

        internal void OnConsoleCommand(SendingConsoleCommandEventArgs ev)
        {
            if(ev.Name == "079")
            {
                if(ev.Arguments.Count < 2)
                {
                    ev.ReturnMessage = "<i><color=red>Ayuda</color></i>";
                    ev.ReturnMessage = "<i>.079 help/? muestra este mensaje";
                    ev.ReturnMessage = "<i>.079 suicide te lleva al expectador (solo si no quedan SCPs)</i>";
                    ev.ReturnMessage = "<i>.079 chaos manda un mensaje fake del cassie (spawn de chaos)</i>";
                    ev.ReturnMessage = "<i>.079 mtf manda un mensaje fake del cassie (spawn de mtf)</i>";
                    return;
                }
                switch (ev.Arguments[0])
                {
                    case "help":
                    case "?":
                        ev.ReturnMessage = "<i><color=red>Ayuda</color></i>";
                        ev.ReturnMessage = "<i>.079 help/? muestra este mensaje";
                        ev.ReturnMessage = "<i>.079 suicide te lleva al expectador (solo si no quedan SCPs)</i>";
                        ev.ReturnMessage = "<i>.079 chaos manda un mensaje fake del cassie (spawn de chaos) (Tier 2, Energia 60)</i>";
                        ev.ReturnMessage = "<i>.079 mtf manda un mensaje fake del cassie (spawn de mtf) (Tier 2, Energia 60)</i>";
                        break;
                    case "suicide":
                        if(ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        IEnumerable<Player> enumerable = Player.List.Where(x => x.Team == Team.SCP);
                        List<Player> pList = enumerable.ToList();
                        if(pList.Count == 0 && pList[0].Role == RoleType.Scp079)
                        {
                            Player player = pList[0];
                            ev.ReturnMessage = "<i>Mandandote a espectador</i>";
                            player.SetRole(RoleType.Spectator);
                        }
                        break;
                    case "chaos":
                        if (ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        if (!Pasivaa[ev.Player.Id.ToString()]) { ev.ReturnMessage = "Habilidad en cooldown"; return; }
                        if(ev.Player.Energy < 60 && ev.Player.Level < 2) { ev.ReturnMessage = "Necesitas Tier 2 y 60 de energia para usar este comando"; return; }
                        ev.ReturnMessage = "<i>Fakeando el spawn de chaos</i>";
                        Cassie.Message("");
                        Pasivaa[ev.Player.Id.ToString()] = false;
                        MEC.Timing.RunCoroutine(Cooldown0792(ev.Player));
                        break;
                    case "mtf":
                        if (ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        if (!Pasivaa[ev.Player.Id.ToString()]) { ev.ReturnMessage = "Habilidad en cooldown"; return; }
                        if (ev.Player.Energy < 60 && ev.Player.Level < 2) { ev.ReturnMessage = "Necesitas Tier 2 y 60 de energia para usar este comando"; return; }
                        ev.ReturnMessage = "<i>Fakeando el spawn de mtf</i>";
                        Cassie.Message("");
                        Pasivaa[ev.Player.Id.ToString()] = false;
                        MEC.Timing.RunCoroutine(Cooldown0792(ev.Player));
                        break;

                }

            }
        }
    }
}
