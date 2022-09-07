using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadingView : HomeSceneViewBase
{
    public Slider loadingBar;
    [SerializeField] Text loadingText;
    public override void OnSetup()
    {
        loadingBar.maxValue = 1;
        loadingBar.minValue = 0;
        loadingBar.value = 0;
    }
    private void Start()
    {
        loadingBar.maxValue = 1;
        loadingBar.minValue = 0;
        loadingBar.value = 0;
    }
    private void Update()
    {
        

    }
    public void SettingProgress(float value)
    {
        loadingBar.value = value;
        if (loadingBar.value < 1)
        {
            loadingText.text = ((int)(loadingBar.value * 100f)).ToString() + "/100";
        }       
    }
}
