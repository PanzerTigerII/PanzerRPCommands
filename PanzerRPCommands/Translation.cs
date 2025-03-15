using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RPCommands_WithoutHSM;

namespace PanzerRPCommands
{
    public class Translation : ITranslation
    {
        [Description("Wiadomość się pokaże kiedy runda się jeszcze nie zaczeła")]
        public string RoundNotStarted { get; set; } = "Nie możesz użyć jeszcze komendy bo runda się nie zaczeła!";

        [Description("Wiadomość o użyciu komendy.")]
        public string Usage { get; set; } = "Wiadomość: .{0} <message>";

        [Description("Wiadomość się pokaże kiedy nie graćz chce użyć komendy.")]
        public string OnlyPlayers { get; set; } = "Tylko gracze mogą użyć tej komendy.";

        [Description("Wiadomość się pokaże kiedy komenda zadziała poprawnie")]
        public string MessageSent { get; set; } = "Twoja komenda zadziałała poprawnie.";

        [Description("Wiadomość się pokaże kiedy opis zostanie ustawiony.")]
        public string CustomInfoSet { get; set; } = "Twój opis został ustawiony!";

        [Description("Wiadomość się pokaże kiedy .opis jest zbyt długie")]
        public string CustomInfoTooLong { get; set; } = "Opis jest zbyt długi.";

        [Description("Wiadomość która się pokaże prz próbie użycia wyłączonej komendy")]
        public string CommandDisabled { get; set; } = "Ta komenda jest wyłączona.";

        [Description("Wiadomość zostanie pokazana kiedy ktoś użyje .pomoc")]
        public string HelpRequestSent { get; set; } = "Twoja Wiadomość została wysłana do staff'u.";


        [Description("Zbiór komend")]

        public Dictionary<string, string> CommandNames { get; set; } = new()
        {
            { "me", "me" },
            { "do", "do" },
            { "look", "look" },
            { "ooc", "ooc" },
            { "try", "try" },
            { "desc", "desc" },
            { "opis", "opis" },
            { "pomoc", "pomoc" },
        };

        [Description("Zbiór tego co robią dane komendy")]
        public Dictionary<string, string> Commands { get; set; } = new()
        {
            { "me", "Komenda Narracyjna 'Me'." },
            { "do", "Komenda Narracyjna 'Do'." },
            { "look", "Komenda Narracyjna 'Look'." },
            { "ooc", "Komenda Narracyjna 'Ooc'." },
            { "try", "Komenda Narracyjna 'Try'." },
            { "desc", "Komenda Narracyjna 'Desc'." },
            { "opis", "Ustawia opis." },
            { "pomoc", "Wysyła wiadomość do staffu serwera" },
        };

        [Description("Zbiór tego co może się stać po użyciu .try")]
        public Dictionary<string, string> TryResult { get; set; } = new()
        {
            { "Udane", "Udane" },
            { "NieUdane", "NieUdane" }
        };

        public string GetOriginalCommandName(string translatedName)
        {
            return Plugin.Instance.Translation.CommandNames
                .FirstOrDefault(x => x.Value == translatedName).Key ?? translatedName;
        }
    }
}
