using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using isoLand.Manager;
namespace isoLand.Facades
{
    // 
    public static class AllManagers
    {
        public static UIManager uiManager;
        public static AudioManager audioManager;
        // ≥ı ºªØ
        public static void Ctor()
        {
            uiManager = null;
            audioManager = null;
        }
    }
}

