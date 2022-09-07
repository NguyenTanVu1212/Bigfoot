using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DialogOnClick : MonoBehaviour, IPointerExitHandler , IPointerEnterHandler , IDeselectHandler 
{
    bool mouseIsOver ;
    private void Start()
    {       
        mouseIsOver = true;
    }
    
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("");
        if (mouseIsOver)
        {
            DialogManager.instance.HideDialog(DialogManager.instance.currentDialog);
        }
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsOver = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIsOver = true;
        EventSystem.current.SetSelectedGameObject(gameObject);

    }
   
    
}
