using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace isoLand.Assets
{
    public class GameAssets
    {
        Dictionary<string, GameObject> uiAssets;
        Dictionary<string, GameObject> audioAssets;
        public GameAssets()
        {
            uiAssets = new Dictionary<string, GameObject>();
            audioAssets = new Dictionary<string, GameObject>();
        }
        public async Task LoadAllAssets()
        {
            await LoadUI();
            await LoadAudio();
        }
        async Task LoadUI()
        {
            // 异步加载所有AA包列表里面的东西
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "UIAssets";
            IList<GameObject> res = await Addressables.LoadAssetsAsync<GameObject>(labelReference, null).Task;
            foreach (GameObject go in res)
            {
                uiAssets.Add(go.name, go);
            }
        }
        async Task LoadAudio()
        {
            // 异步加载所有AA包列表里面的东西
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "AudioAssets";
            IList<GameObject> res = await Addressables.LoadAssetsAsync<GameObject>(labelReference, null).Task;
            foreach (GameObject go in res)
            {
                audioAssets.Add(go.name, go);
            }
        }
    }
}

