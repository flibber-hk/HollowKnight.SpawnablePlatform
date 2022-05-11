using System;
using System.Collections.Generic;
using System.Linq;
using Modding;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpawnablePlatform
{
    public class SpawnablePlatformMod : Mod, IGlobalSettings<GlobalSettings>, ILocalSettings<LocalSettings>
    {
        public static GlobalSettings GS = new();
        public GlobalSettings OnSaveGlobal() => GS;
        public void OnLoadGlobal(GlobalSettings gs)
        {
            if (gs.KeyBinds == null)
            {
                gs.KeyBinds = new();
            }
            
            GS = gs;
        }

        public static LocalSettings LS = new();
        public LocalSettings OnSaveLocal() => LS;
        public void OnLoadLocal(LocalSettings ls) => LS = ls;


        internal static SpawnablePlatformMod instance;
        
        public SpawnablePlatformMod() : base(null)
        {
            instance = this;
        }
        
        public override string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }

        public override List<(string, string)> GetPreloadNames() => ObjectCache.GetPreloadNames();

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Initializing Mod...");

            ObjectCache.Initialize(preloadedObjects);

            ModHooks.HeroUpdateHook += Listen;
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += PlacePlatform;
        }

        private static readonly Vector2 platformOffset = new(0, -1.8f);

        private GameObject currentPlatform;

        private void Listen()
        {
            if (GS.KeyBinds.PlacePlatform.WasPressed)
            {
                PlacePlatform();
            }
            else if (GS.KeyBinds.RemovePlatform.WasPressed)
            {
                RemovePlatform();
            }
        }

        private void PlacePlatform()
        {
            RemovePlatform();
            LS.PlatformScene = GameManager.instance.sceneName;
            LS.PlatformPosition = (Vector2)HeroController.instance.transform.position + platformOffset;

            SpawnPlatform();
        }

        private void SpawnPlatform()
        {
            currentPlatform = ObjectCache.SmallPlatform;
            currentPlatform.transform.SetPosition2D(LS.PlatformPosition);
            currentPlatform.SetActive(true);
        }

        private void RemovePlatform()
        {
            if (currentPlatform != null)
            {
                UnityEngine.Object.Destroy(currentPlatform);
                currentPlatform = null;
            }

            LS.PlatformScene = null;
            LS.PlatformPosition = default;
        }

        private void PlacePlatform(Scene _, Scene scene)
        {
            currentPlatform = null;

            if (scene.name == LS.PlatformScene)
            {
                SpawnPlatform();
            }
        }
    }
}