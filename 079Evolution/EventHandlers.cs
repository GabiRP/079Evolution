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
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        bool Coold = true;
        bool Cooldw = true;


        // cooldown de habilidad
        private IEnumerator<float> Cooldown0792(Player player)
        {

            yield return MEC.Timing.WaitForSeconds(60f);
            Coold = true;

        }
        private IEnumerator<float> Cooldown0793(Player player)
        {

            yield return MEC.Timing.WaitForSeconds(120f);
            Cooldw = true;
        }


        internal void OnConsoleCommand(SendingConsoleCommandEventArgs ev)
        {
            if(ev.Name == "079")
            {
                if(ev.Arguments.Count < 1)
                {
                    ev.Player.SendConsoleMessage("Ayuda", "yellow");
                    ev.Player.SendConsoleMessage(".079 help/? muestra este mensaje", "yellow");
                    ev.Player.SendConsoleMessage(".079 suicide te lleva al expectador (solo si no quedan SCPs)", "yellow");
                    ev.Player.SendConsoleMessage(".079 chaos manda un mensaje fake del cassie (spawn de chaos)", "yellow");
                    ev.Player.SendConsoleMessage(".079 mtf manda un mensaje fake del cassie (spawn de mtf)", "yellow");
                    return;
                }
                switch (ev.Arguments[0])
                {
                    case "help":
                    case "?":
                        ev.Player.SendConsoleMessage("Ayuda", "yellow");
                        ev.Player.SendConsoleMessage(".079 help/? muestra este mensaje", "yellow");
                        ev.Player.SendConsoleMessage(".079 suicide te lleva al expectador (solo si no quedan SCPs)", "yellow");
                        //ev.Player.SendConsoleMessage(".079 chaos manda un mensaje fake del cassie (spawn de chaos))", "yellow");
                        //ev.Player.SendConsoleMessage(".079 mtf manda un mensaje fake del cassie (spawn de mtf)", "yellow");
                        ev.Player.SendConsoleMessage(".079 blackout apaga las luces de todas las instalaciones durante 8 segundos", "yellow");
                        break;
                    case "suicide":
                        if(ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        IEnumerable<Player> enumerable = Player.List.Where(x => x.Team == Team.SCP);
                        List<Player> pList = enumerable.ToList();
                        if(pList.Count == 1 && pList[0].Role == RoleType.Scp079)
                        {
                            Player player = pList[0];
                            ev.ReturnMessage = "<i>Mandandote a espectador</i>";
                            player.SetRole(RoleType.Spectator);
                        }
                        break;
                    case "chaos":
                        if (ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        if (!Coold) { ev.ReturnMessage = "Habilidad en cooldown"; return; }
                        if(ev.Player.Energy < 60 || ev.Player.Level < 2) { ev.ReturnMessage = "Necesitas Tier 2 y 60 de energia para usar este comando"; return; }
                        ev.ReturnMessage = "<i>Fakeando el spawn de chaos</i>";
                        Cassie.Message("pitch_0.5 .g3 .g3 . pitch_1 Danger . Danger . Unauthorized access detected at surface Gate A . All security units report to Entrance Zone in order to stop the intruders pitch_0.5 .g3");
                        Coold = false;
                        int p = (int)System.Environment.OSVersion.Platform;
                        if ((p == 4) || (p == 6) || (p == 128)) MEC.Timing.RunCoroutine(Cooldown0792(ev.Player), MEC.Segment.Update);
                        else MEC.Timing.RunCoroutine(Cooldown0792(ev.Player), 1);
                        break;
                    case "mtf":
                        if (ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        if (!Coold) { ev.ReturnMessage = "Habilidad en cooldown"; return; }
                        if (ev.Player.Energy < 60 || ev.Player.Level < 2) { ev.ReturnMessage = "Necesitas Tier 2 y 60 de energia para usar este comando"; return; }
                        IEnumerable<Player> spcs = Player.List.Where(x => x.Team == Team.SCP);
                        List<Player> plList = spcs.ToList();
                        ev.ReturnMessage = "<i>Fakeando el spawn de mtf</i>";
                        Cassie.Message($"pitch_0.3 .g3 .g3 . pitch_1 Attention all Foundation personnel . MtfUnit Epsilon 11 designated Nato_A 1 hasentered .  AllRemaining AwaitingRecontainment {plList.Count} SCPsubjects .");
                        Coold = false;
                        int pl = (int)System.Environment.OSVersion.Platform;
                        if ((pl == 4) || (pl == 6) || (pl == 128)) MEC.Timing.RunCoroutine(Cooldown0792(ev.Player), MEC.Segment.Update);
                        else MEC.Timing.RunCoroutine(Cooldown0792(ev.Player), 1);
                        break;
                    case "blackout":
                        if (ev.Player.Role != RoleType.Scp079) { ev.ReturnMessage = "No puedes usar este comando si no eres SCP-079"; return; }
                        if (!Cooldw) { ev.ReturnMessage = "Habilidad en cooldown"; return; }
                        if (ev.Player.Energy < 100 || ev.Player.Level < 3) { ev.ReturnMessage = "Necesitas Tier 2 y 60 de energia para usar este comando"; return; }
                        //adas
                        Cassie.Message("pitch_0.5 .g3 .g3 .g3 pitch_1 Danger . SCP 0 7 9 Will turn off the light system in 3 . 2 . 1 ");
                        Timing.CallDelayed(10f, () => { Map.TurnOffAllLights(8f); });
                        Cooldw = false;
                        int plt = (int)System.Environment.OSVersion.Platform;
                        if ((plt == 4) || (plt == 6) || (plt == 128)) Timing.RunCoroutine(Cooldown0793(ev.Player), MEC.Segment.Update);
                        else Timing.RunCoroutine(Cooldown0793(ev.Player), 1);
                        break;


                }

            }
        }
    }
}
