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
        MainController mainController;
        CursorController cursorController;
        void Awake()
        {

        }
        void Start()
        {
            // 初始化 Facades
            //AllAssets.Ctor();
            //AllManagers.Ctor();
            // 初始化 Controllers
            cursorController = new CursorController();
            cursorController.Ctor();
            //audioController = new AudioController();
            //audioController.Ctor();
            mainController = new MainController();
            mainController.Ctor();
            // 通过maincontroller加载Assets
            EventCenter.Boardcast<string>(MyEventType.SceneChangeUIFade, "fadeIn");
        }
        void Update()
        {
            //if (!isInit) return;
            cursorController.Tick();
        }
    }
}

