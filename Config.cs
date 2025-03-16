using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PanzerRPCommands
{
    public class Config : IConfig
    {
        [Description("true = Plugin Właczony, false = Plugin Wyłączony")]
        public bool IsEnabled { get; set; } = true;

        [Description("Włącz tryb Debug - Nie działa")]
        public bool Debug { get; set; } = false;

        [Description("Ustawienia komend - Nie usuwać {0}, {1}, lub {2}")]
        public CommandSettings Me { get; set; } = new(15f, 5f, "<size=25><align=left><color=Red>「Me」</color><color=#FFFF00>{0}</color> : \n{1}</align></size>");
        public CommandSettings Do { get; set; } = new(15f, 5f, "<size=25><align=left><color=green>「Do」</color><color=#FFFF00>{0}</color> : \n{1}</align></size>");
        public CommandSettings Look { get; set; } = new(15f, 5f, "<size=25><align=left><color=#00FFFF>「Patrz」</color><color=#FFFF00>{0}</color> : \n{1}</align></size>");
        public CommandSettings Ooc { get; set; } = new(15f, 5f, "<size=25><align=left><color=yellow>「Ooc」</color><color=#FFFF00>{0}</color> : \n{1}</align></size>");
        public CommandSettings Try { get; set; } = new(15f, 5f, "<size=25><align=left><color=yellow>「Try」</color><color=#FFFF00>{0}</color> : \n{1} | {2} </align></size>");
        public CommandSettings Desc { get; set; } = new(15f, 5f, "<size=25><align=left><color=blue>「Opis」</color><color=#FFFF00>{0}</color> : \n{1}</align></size>");
        public CommandSettings Assist { get; set; } = new(0f, 0f, "<color=green>[ModMail]</color> <color=#ffcc00>{0}</color>: {1}");

        [Description("Maksymalna ilość znaków dla .opis")]
        public int MaxCustomInfoLength { get; set; } = 250;

        [Description("Włącza lub wyłącza daną komende")]
        public Dictionary<string, bool> EnabledCommands { get; set; } = new()
        {
            { "me", true },
            { "do", true },
            { "patrz", true },
            { "ooc", true },
            { "try", true },
            { "desc", true },
            { "opis", true },
            { "pomoc", true }
        };

        public bool IsCommandEnabled(string command) => EnabledCommands.ContainsKey(command) && EnabledCommands[command];

        public float GetRange(string command) => GetSettings(command).Range;
        public float GetDuration(string command) => GetSettings(command).Duration;
        public string FormatMessage(string command, params object[] args) => string.Format(GetSettings(command).Format, args);

        private CommandSettings GetSettings(string command) => command switch
        {
            "me" => Me,
            "do" => Do,
            "patrz" => Look,
            "ooc" => Ooc,
            "try" => Try,
            "desc" => Desc,
            "pomoc" => Assist,
            _ => throw new ArgumentException("Zła Komenda!", nameof(command))
        };
    }

    public class CommandSettings
    {
        public float Range { get; set; }
        public float Duration { get; set; }
        public string Format { get; set; }

        public CommandSettings() { }
        public CommandSettings(float range, float duration, string format)
        {
            Range = range;
            Duration = duration;
            Format = format;
        }
    }
}
