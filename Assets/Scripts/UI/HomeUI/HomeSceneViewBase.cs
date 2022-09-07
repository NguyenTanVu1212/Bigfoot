using UnityEngine;
using System;

public class HomeSceneViewBase : MonoBehaviour
{
    public HomeSceneViewIndex viewIndex;
    public HomeSceneViewAnimationBase baseAnimation;
    public static HomeSceneViewIndex nextView;
    public static bool isLoadGame;

    private void Awake()
    {
        baseAnimation = GetComponentInChildren<HomeSceneViewAnimationBase>();
        isLoadGame = false;
    }
    public void ShowView(Action callBack)
    {
        OnSetup();
        baseAnimation.ShowAnimation(()=>{            
            callBack?.Invoke();
            OnShowView();
        });
    }
    public virtual void OnSetup()
    {

    }
    public virtual void OnShowView()
    {

    }

    public void HideView(Action callBack)
    {
        baseAnimation.HideAnimation(()=> {           
            OnHideView();
            callBack?.Invoke();
        });
    }
    public virtual void OnHideView()
    {

    }
}
