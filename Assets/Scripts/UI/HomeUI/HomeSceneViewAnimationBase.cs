using UnityEngine;
using System;

public class HomeSceneViewAnimationBase : MonoBehaviour
{
    public virtual void ShowAnimation(Action callBack)
    {
        callBack?.Invoke();
    }
    public virtual void HideAnimation(Action callBack)
    {
        callBack?.Invoke();
    }
}
