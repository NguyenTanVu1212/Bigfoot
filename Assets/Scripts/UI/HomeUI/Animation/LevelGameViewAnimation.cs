using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class LevelGameViewAnimation : HomeSceneViewAnimationBase
{
    public CanvasGroup canvasGroup;
    public override void ShowAnimation(Action callBack)
    {
        //base.ShowAnimation(callBack);
        canvasGroup.DOFade(1, 0f).OnComplete(() =>
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
