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
            // ��ʼ�� Facades
            //AllAssets.Ctor();
            //AllManagers.Ctor();
            // ��ʼ�� Controllers
            cursorController = new CursorController();
            cursorController.Ctor();
            //audioController = new AudioController();
            //audioController.Ctor();
            mainController = new MainController();
            mainController.Ctor();
            // ͨ��maincontroller����Assets
            EventCenter.Boardcast<string>(MyEventType.SceneChangeUIFade, "fadeIn");
        }
        void Update()
        {
            //if (!isInit) return;
            cursorController.Tick();
        }
    }
}

