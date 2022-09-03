using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using isoLand.Manager;
using isoLand.Models;
using isoLand.Facades;
using isoLand.Controller;
using EventSystem;

namespace isoLand.Main
{
    public class App : MonoBehaviour
    {
        bool isInit;
        [SerializeField] public string startScene;
        MainController mainController;
        CursorController cursorController;
        TransitionController transitionController;
        AudioManager audioManager;
        void Awake()
        {
            // --- 初始化controllers ---
            cursorController = new CursorController();
            cursorController.Init();
            transitionController = GetComponentInChildren<TransitionController>();
            transitionController.Init();
            InventoryController inventoryController = GetComponentInChildren<InventoryController>();
            inventoryController.Init();
            audioManager = GetComponentInChildren<AudioManager>();
            audioManager.Init();
        }
        void Start()
        {
            #region 不要的
            // 通过maincontroller加载Assets
            //audioController = new AudioController();
            //audioController.Ctor();
            //mainController = new MainController();
            //mainController.Ctor();
            #endregion
            EventCenter.Boardcast<string, string>(MyEventType.ScenceChange, string.Empty, startScene);
            //EventCenter.Boardcast<AudioSourceType, string, bool, float>(MyEventType.PlaySound, AudioSourceType.BackGround, "OpenRoad", true, 0.5f);
        }
        void Update()
        {
            //if (!isInit) return;
            cursorController.Tick();
        }
        private void OnDestroy() {
            cursorController.Destroy();
        }
    }
}

