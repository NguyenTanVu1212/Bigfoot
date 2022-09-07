using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dialog_ShowCardReview : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IDeselectHandler
{
    [SerializeField] CardDemo card;
    bool isMouseOver;
    public void OnDeselect(BaseEventData eventData)
    {
        if(!isMouseOver)
        {
            card.OnClick?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = false;
        CardReviewDialogParam param = new CardReviewDialogParam();
        DialogManager.instance.HideAllDialog();
        param.id = card.id;
        DialogManager.instance.ShowDialog(DialogIndex.CardReviewDialog, param, () =>
        {
            
            //DialogManager.instance.currentDialog.transform.position = card.touchPanel.position;
            DialogManager.instance.currentDialog.transform.SetParent(card.touchPanel.transform);
            DialogManager.instance.currentDialog.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            //DialogManager.instance.currentDialog.GetComponent<RectTransform>().sizeDelta = new Vector2(900 , 600);
        }
        );
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = true;
        //DialogManager.instance.currentDialog.transform.SetParent(null);
        //DialogManager.instance.HideAllDialog();
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        isMouseOver = true;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    
}
