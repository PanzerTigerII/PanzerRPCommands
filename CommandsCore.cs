using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using System.Linq;
using RPCommands_WithoutHSM;
using UnityEngine;

namespace PanzerRPCommands
{
    public abstract class NarrativeCommand : ICommand
    {
        public abstract string OriginalCommand { get; }
        public virtual string[] Aliases => Array.Empty<string>();
        public abstract string Description { get; }

        public string Command => Plugin.Instance.Translation.CommandNames.TryGetValue(OriginalCommand, out string translatedName) ? translatedName : OriginalCommand;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.Config.IsCommandEnabled(OriginalCommand))
            {
                response = Plugin.Instance.Translation.CommandDisabled;
                return false;
            }
            if (!Round.IsStarted)
            {
                response = Plugin.Instance.Translation.RoundNotStarted;
                return false;
            }

            if (arguments.Count < 1)
            {
                response = string.Format(Plugin.Instance.Translation.Usage, Command);
                return false;
            }

            if (sender is not PlayerCommandSender playerSender)
            {
                response = Plugin.Instance.Translation.OnlyPlayers;
                return false;
            }

            Player player = Player.Get(playerSender.ReferenceHub);
            string message = string.Join(" ", arguments);
            float range = Plugin.Instance.Config.GetRange(OriginalCommand);
            float duration = Plugin.Instance.Config.GetDuration(OriginalCommand);
            string formattedMessage = FormatMessage(player, message);

            HintToNearbyPlayers(player, formattedMessage, range, duration);
            response = Plugin.Instance.Translation.MessageSent;
            return true;
        }

        protected virtual string FormatMessage(Player player, string message)
        {
            return Plugin.Instance.Config.FormatMessage(OriginalCommand, player.Nickname, message);
        }

        private void HintToNearbyPlayers(Player sender, string message, float range, float duration)
        {
            foreach (Player player in Player.List.Where(p => p != sender && Vector3.Distance(p.Position, sender.Position) <= range))
            {
                player.ShowHint(message, duration);
            }
            sender.ShowHint(message, duration);
        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class MeCommand : NarrativeCommand
    {
        public override string OriginalCommand => "me";
        public override string Description => Plugin.Instance.Translation.Commands["me"];
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class DoCommand : NarrativeCommand
    {
        public override string OriginalCommand => "do";
        public override string Description => Plugin.Instance.Translation.Commands["do"];
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class LookCommand : NarrativeCommand
    {
        public override string OriginalCommand => "look";
        public override string Description => Plugin.Instance.Translation.Commands["look"];
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class OocCommand : NarrativeCommand
    {
        public override string OriginalCommand => "ooc";
        public override string Description => Plugin.Instance.Translation.Commands["ooc"];
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class DescCommand : NarrativeCommand
    {
        public override string OriginalCommand => "desc";
        public override string Description => Plugin.Instance.Translation.Commands["desc"];
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class CustomInfoCommand : ICommand
    {
        public string Command => Plugin.Instance.Translation.CommandNames.TryGetValue("opis", out string translatedName) ? translatedName : "opis";
        public string[] Aliases => Array.Empty<string>();
        public string Description => Plugin.Instance.Translation.Commands["opis"];

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.Config.IsCommandEnabled("opis"))
            {
                response = Plugin.Instance.Translation.CommandDisabled;
                return false;
            }

            if (sender is not PlayerCommandSender playerSender)
            {
                response = Plugin.Instance.Translation.OnlyPlayers;
                return false;
            }

            Player player = Player.Get(playerSender.ReferenceHub);

            if (arguments.Count < 1)
            {
                response = string.Format(Plugin.Instance.Translation.Usage, Command);
                return false;
            }

            string customInfo = string.Join(" ", arguments);
            int maxLength = Plugin.Instance.Config.MaxCustomInfoLength;

            if (customInfo.Length > maxLength)
            {
                response = Plugin.Instance.Translation.CustomInfoTooLong;
                return false;
            }

            player.CustomInfo = customInfo;
            response = Plugin.Instance.Translation.CustomInfoSet;
            return true;
        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class HelpCommand : ICommand
    {
        public string Command => Plugin.Instance.Translation.CommandNames.TryGetValue("pomoc", out string translatedName) ? translatedName : "pomoc";
        public string[] Aliases => Array.Empty<string>();
        public string Description => Plugin.Instance.Translation.Commands["pomoc"];

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.Config.IsCommandEnabled("pomoc"))
            {
                response = Plugin.Instance.Translation.CommandDisabled;
                return false;
            }

            if (sender is not PlayerCommandSender playerSender)
            {
                response = Plugin.Instance.Translation.OnlyPlayers;
                return false;
            }

            if (arguments.Count < 1)
            {
                response = string.Format(Plugin.Instance.Translation.Usage, Command);
                return false;
            }

            Player player = Player.Get(playerSender.ReferenceHub);
            string message = string.Join(" ", arguments);
            string formattedMessage = Plugin.Instance.Config.FormatMessage("pomoc", player.Nickname, message);

            foreach (Player staff in Player.List.Where(p => p.ReferenceHub.serverRoles.RemoteAdmin))
            {
                staff.SendStaffMessage(formattedMessage);
            }

            response = Plugin.Instance.Translation.HelpRequestSent;
            return true;
        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]
    public class TryCommand : NarrativeCommand
    {
        public override string OriginalCommand => "try";
        public override string Description => Plugin.Instance.Translation.Commands["try"];

        protected override string FormatMessage(Player player, string message)
        {
            bool isSuccess = UnityEngine.Random.Range(0, 2) == 0;
            string resultKey = isSuccess ? "Udane" : "NieUdane";
            string result = Plugin.Instance.Translation.TryResult[resultKey];

            return Plugin.Instance.Config.FormatMessage("try", player.Nickname, message, result);
        }
    }
}
