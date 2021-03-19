using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _079Evolution.Commands.SubCommands;
using Exiled.API.Features;

namespace _079Evolution.Commands
{
    public class _079 : ParentCommand
    {
        public override string Command { get; } = "079";

        public override string[] Aliases { get; } = { "079" };

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
            
            Player ply = Player.Get((CommandSender)sender);
            if(ply.Role != RoleType.Scp079)
            {
                response = "Tienes que ser SCP-079 para poder ejecutar este comando";
                return false;
            }
            response = "Ayuda\n.079 ?/help - Muestra este mensaje\n.079 suicide - Te manda a espectador (Si no quedan otros SCPs)\n.079 chaos - Fakea el spawn de Chaos (Nivel 2 Energia 60) Cooldown: 60sec\n.079 mtf - Fakea el spawn de MTF (Nivel 2 Energia 60) Cooldown: 60sec\n.079 blackout - Apaga las luces de toda la instalacion durante 8 segundos";
            return false;
        }
    }
}
