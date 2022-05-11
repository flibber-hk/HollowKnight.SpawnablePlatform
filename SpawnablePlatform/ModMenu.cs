using System;
using Modding;
using Satchel.BetterMenus;

namespace SpawnablePlatform
{
    internal static class ModMenu
    {
        private static Menu MenuRef;

        public static MenuScreen GetMenuScreen(MenuScreen modListMenu)
        {
            MenuRef = new Menu(SpawnablePlatformMod.instance.GetName(), new Element[]
            {
                new KeyBind("Place Platform", SpawnablePlatformMod.GS.KeyBinds.PlacePlatform),
                new KeyBind("Destroy Platform", SpawnablePlatformMod.GS.KeyBinds.RemovePlatform),
            });

            return MenuRef.GetMenuScreen(modListMenu);
        }
    }
}
