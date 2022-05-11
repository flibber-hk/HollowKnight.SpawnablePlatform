using InControl;
using Modding.Converters;
using Newtonsoft.Json;
using UnityEngine;

namespace SpawnablePlatform
{
    public class GlobalSettings
    {
        [JsonConverter(typeof(PlayerActionSetConverter))]
        public KeyBinds KeyBinds { get; set; } = new();
    }

    public class KeyBinds : PlayerActionSet
    {
        public PlayerAction PlacePlatform;
        public PlayerAction RemovePlatform;

        public KeyBinds()
        {
            PlacePlatform = CreatePlayerAction(nameof(PlacePlatform));
            RemovePlatform = CreatePlayerAction(nameof(RemovePlatform));
            DefaultBinds();
        }

        private void DefaultBinds()
        {
            PlacePlatform.AddDefaultBinding(Key.P);
            RemovePlatform.AddDefaultBinding(Key.L);
        }
    }

    public class LocalSettings
    {
        public string PlatformScene { get; set; } = null;
        public Vector2 PlatformPosition { get; set; }
    }
}
