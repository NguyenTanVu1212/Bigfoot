using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class GameViewAnimation : HomeSceneViewAnimationBase
{
    public CanvasGroup canvasGroup;
    public GameObject topPanel, midPanel, botPanel;
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
        // base.HideAnimation(callBack);
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            callBack?.Invoke();
        });
    }
}
