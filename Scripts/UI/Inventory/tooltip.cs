using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tooltip : MonoBehaviour
{
    public Text tooltipText;
    void Start()
    {
        tooltipText.text = "事件监听切换";
    }
}
