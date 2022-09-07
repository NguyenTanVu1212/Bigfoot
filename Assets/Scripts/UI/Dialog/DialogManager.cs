using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    Dictionary<DialogIndex, BaseDialog> dicDialog = new Dictionary<DialogIndex, BaseDialog>();
    public DialogIndex currentIndex;
    public BaseDialog currentDialog;
    public List<BaseDialog> lsDialog = new List<BaseDialog>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    private void Start()
    {
        foreach(DialogIndex e in DialogConfig.dialogs)
        {
            string s = e.ToString();
            GameObject dialogObj = Instantiate(Resources.Load("UI/Dialog/" + s , typeof(GameObject)) as GameObject , transform);
            RectTransform rect = dialogObj.GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            BaseDialog dialog = dialogObj.GetComponent<BaseDialog>();
            dicDialog.Add(dialog.dialogIndex , dialog);
            dialog.gameObject.SetActive(false);
        }
    }
    public void ShowDialog(DialogIndex index, DialogParam param = null, Action callBack = null)
    {
        currentDialog = dicDialog[index];

        currentDialog.ShowDialog(param, callBack);
        lsDialog.Add(currentDialog);
    }
    public void HideDialog(BaseDialog dialog, Action callBack = null)
    {
        dialog.HideDialog(null , callBack);
        lsDialog.Remove(dialog);
    }
    public void HideAllDialog(Action callBack = null)
    {
        if (lsDialog.Count == 0) return;
        for (int i = 0; i < lsDialog.Count - 1; i++)
        {
            lsDialog[i].HideDialog(null);

        }
        lsDialog[lsDialog.Count - 1].HideDialog(null ,callBack);
        lsDialog.Clear();
    }

}
