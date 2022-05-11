using Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpawnablePlatform
{
    internal static class ObjectCache
    {
        private static Dictionary<string, GameObject> _gameObjects = new();

        private static Dictionary<string, (string, string)> _preloads = new()
        {
            ["Platform"] = ("Tutorial_01", "_Scenery/plat_float_17"),
        };

        public static GameObject SmallPlatform => UnityEngine.Object.Instantiate(_gameObjects["Platform"]);

        public static List<(string, string)> GetPreloadNames()
        {
            return _preloads.Values.ToList();
        }

        public static void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            foreach ((string name, (string scene, string path)) in _preloads)
            {
                _gameObjects[name] = preloadedObjects[scene][path];
            }
        }
    }
}
