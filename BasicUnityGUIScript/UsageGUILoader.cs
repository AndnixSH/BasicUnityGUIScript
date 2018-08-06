using System;
using UnityEngine;

namespace BasicUnityGUIScript
{
    public static class UsageGUILoader
    {
        public static string UsageGUIObj = "UsageGUI";

        public static bool AlreadyLoaded()
        {
            return GameObject.Find(UsageGUIObj) != null;
        }

        public static void Load_My_UsageGUI()
        {
            if(!AlreadyLoaded())
            UnityEngine.Object.DontDestroyOnLoad(new GameObject(UsageGUIObj).AddComponent<UsageGUI>());
        }
    }
}
