using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : HomeSceneViewBase
{
    [SerializeField] GameObject menuGame;
    [SerializeField] public AudioClip backSound;
    public void Btn_Adventure()
    {
       
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.CategoryView, ()=> {

        });
    }
    public override void OnSetup()
    {
        backSound = Resources.Load("newborn.mp3" , typeof(AudioClip)) as AudioClip;
        base.OnSetup();
    }
    public void Btn_MenuGame()
    {
    }
    public void Btn_Arena()
    {
    }
    public void Btn_Setting()
    {
        Debug.Log("Setting");
    }
    public void Btn_Inventory()
    {
        Debug.Log("Inventory");
    }
    public void Btn_MiniGame()
    {

    }
    public void Btn_Shop()
    {
        Debug.Log("Shop");
    }
    
}
