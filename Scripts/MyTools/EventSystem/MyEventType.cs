namespace EventSystem
{
    public enum MyEventType
    {
        Test,
        // 鼠标事件
        MouseClicked,
        ClickTeleport,
        ClickItem,
        // 场景切换
        ScenceChange,
        BeforeScenceChange,
        AfterScenceChange,
        // UI事件
        SceneChangeUIFade,
        InventoryUIUpdate,
        // 音频事件
        Audio,
        PlaySound,
        StopSound,
        PauseSound,
        SetVolum,
        // 背包事件
        AddItem,
        // 互动事件
        ChangeItemAvailable,
        ClickInteractive,
        HoldSomething,
        NoHold,
    }
}
