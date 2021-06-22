using System.ComponentModel;

namespace _079Evolution
{
    public class Translations
    {
        [Description("Broadcast shown to the player that spawns as SCP-079")]
        public string SpawnBroadcast{ get; set; } = "<color=yellow>Now as SCP-079 you have commands! to see all the commands, just use in the game console (`/~).</color>";
        [Description("This is shown in the console to SCP-079 when a command doesn't exist and when a SCP-079 spawns")]
        public string CmdMsg { get; set; } = $"Help\n.079 ?/help - Shows this message\n.079 suicide - Sends you to spectator (Only if there's no other SCPs alive)\n.079 chaos - Fakes Chaos respawn (Lvl 2 - 60 Energy) Cooldown: 60sec\n.079 mtf - Fakes MTF respawn (Lvl 2 60 Energy) Cooldown: 60sec\n.079 blackout - Turns off all the foundation lights for {Plugin.plugin.Config.BlackoutTime}";
        [Description("Message shown when SCP-079 doesn't have enough Energy or Lvl")]
        public string LvlEnergyMsg { get; set; } =
            "<color=red>You don't have enough energy or level to use this command. Check how much Energy/Lvl you need using the command .079 help/?</color>";

        [Description("Message shown to SCP-079 when using .079 suicide and there's other scps")]
        public string OtherScps { get; set; } = "There are still other SCPs";
        [Description("Message shown to SCP-079 when using the Blackout command")]
        public string BlackoutMsg { get; set; } = "<color=green>Turning of the lights</color>";
        [Description("Message shown to SCP-079 when faking Chaos respawn")]
        public string ChaosMsg { get; set; } = "<color=green>Faking Chaos respawn</color>";
        [Description("Message shown to SCP-079 when faking MTF respawn")]
        public string MtfMsg { get; set; } = "<color=green>Faking MTFs respawn</color>";
        [Description("Message shown to SCP-079 when using Suicide command")]
        public string SuicideMsg { get; set; } = "<color=green>Sending you to spectator</color>";
        [Description("Message shown when a user uses any 079 command without being 079")]
        public string NoRole { get; set; } = "<color=red>You need to be SCP-079 to use this command</color>";
        [Description("Message shown to SCP-079 when he is in cooldown for any command")]
        public string Cooldown { get; set; } = "<color=orange>You are in cooldown for this command</color>";

        
    }
}