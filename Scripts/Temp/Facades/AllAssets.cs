using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using isoLand.Assets;

namespace isoLand.Facades
{
    public class AllAssets
    {
        public static GameAssets gameAssets;
        public static void  Ctor()
        {
            gameAssets = new GameAssets();
        }
    }
}


