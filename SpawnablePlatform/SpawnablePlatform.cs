using System;
using System.Collections.Generic;
using System.Linq;
using Modding;
using UnityEngine;

namespace SpawnablePlatform
{
    public class SpawnablePlatform : Mod
    {
        internal static SpawnablePlatform instance;
        
        public SpawnablePlatform() : base(null)
        {
            instance = this;
        }
        
        public override string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
        
        public override void Initialize()
        {
            Log("Initializing Mod...");
            
            
        }
    }
}