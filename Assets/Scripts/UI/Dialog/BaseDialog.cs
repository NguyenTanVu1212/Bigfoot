using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseDialog : MonoBehaviour
{
    public DialogIndex dialogIndex;
    [SerializeField] BaseDialogAnimation baseDialogAnimation;
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        if (baseDialogAnimation == null)
            baseDialogAnimation = GetComponentInChildren<BaseDialogAnimation>();
    }
    public virtual void OnSetup(DialogParam param = null)
    {

    }
    public virtual void OnShow()
    {

    }
    public void ShowDialog(DialogParam param = null , Action callback = null)
    {
        gameObject.SetActive(true);
        rect.SetAsFirstSibling();
        OnSetup(param);
        baseDialogAnimation.ShowDialog(()=> {
            OnShow();
            callback?.Invoke();
        });
    }
    public virtual void OnHideDialog()
    {

    }
    public void HideDialog(DialogParam param = null, Action callback = null)
    {
        baseDialogAnimation.HideDialog(()=> {
            callback?.Invoke();
            gameObject.SetActive(false);
            OnHideDialog();
            
        });
    }
}
