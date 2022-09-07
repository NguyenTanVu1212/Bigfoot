using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CategoryViewAnimation : HomeSceneViewAnimationBase
{
    public CanvasGroup canvasGroup;
    public override void ShowAnimation(Action callBack)
    {
        //base.ShowAnimation(callBack);
        canvasGroup.DOFade(1 , 0f).OnComplete(()=> 
        {
            callBack?.Invoke();
        });
    }

    public override void HideAnimation(Action callBack)
    {
        //base.HideAnimation(callBack);
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            callBack?.Invoke();
        });
    }

}
