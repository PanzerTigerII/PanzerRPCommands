using Exiled.API.Features;
using System;
using PanzerRPCommands;

namespace RPCommands_WithoutHSM
{
    public class Plugin : Plugin<Config, Translation>
    {
        public static Plugin Instance { get; private set; }

        public override string Name => "PanzerRPCommands";
        public override string Author => "Panzer VI Tiger II";
        public override Version Version => new(0, 6, 9);

        public override void OnEnabled()
        {
            Log.Info("Plugin Włączony");
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}
