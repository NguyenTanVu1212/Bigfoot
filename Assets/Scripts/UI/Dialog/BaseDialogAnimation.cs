using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseDialogAnimation : MonoBehaviour
{
    public virtual void ShowDialog(Action callBack)
    {
        callBack?.Invoke();
    }

    public virtual void HideDialog(Action callBack)
    {
        callBack?.Invoke();
    }

}
