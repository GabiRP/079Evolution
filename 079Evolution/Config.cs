using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _079Evolution
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        
        [Description("Broadcast for when 079 spawns")]
        public string SpawnBroadcast{ get; set; } = "<color=yellow>Ahora como SCP-079 tienes comandos! para mirarlos, solo usa la consola del juego (ñ). Ahí tendras la lista de comandos que puedes usar.</color>";
        [Description("SpawnBroadcast duration")]
        public ushort BroadcastDuration { get; set; } = 5;
        
        [Description("Message to show in the game console to the 079 when spawns")]
        public string SpawnCmdMsg { get; set; } = "Ayuda\n.079 ?/help - Muestra este mensaje\n.079 suicide - Te manda a espectador (Si no quedan otros SCPs)\n.079 chaos - Fakea el spawn de Chaos (Nivel 2 Energia 60) Cooldown: 60sec\n.079 mtf - Fakea el spawn de MTF (Nivel 2 Energia 60) Cooldown: 60sec\n.079 blackout - Apaga las luces de toda la instalacion durante 8 segundos";
        [Description("Color for the message above")]
        public string CmdColor { get; set; } = "yellow";
        
        [Description("------Command responses------")]
        public string BadCommandMsg { get; set; } = "Ayuda\n.079 ?/help - Muestra este mensaje\n.079 suicide - Te manda a espectador (Si no quedan otros SCPs)\n.079 chaos - Fakea el spawn de Chaos (Nivel 2 Energia 60) Cooldown: 60sec\n.079 mtf - Fakea el spawn de MTF (Nivel 2 Energia 60) Cooldown: 60sec\n.079 blackout - Apaga las luces de toda la instalacion durante 8 segundos";
        [Description("Blackout command response")]
        public string BlackoutMsg { get; set; } = "Turning Off Lights";
        [Description("Chaos command response")]
        public string ChaosMsg { get; set; } = "Faking Chaos Spawn";
        [Description("Mtf command response")]
        public string MtfMsg { get; set; } = "Faking Mtf Spawn";
        [Description("Suicide command response")]
        public string SuicideMsg { get; set; } = "Sending you to spectator";
        
    }
}
