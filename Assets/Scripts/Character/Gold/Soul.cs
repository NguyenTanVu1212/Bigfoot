using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG;
using System;
using UnityEngine.EventSystems;
public class Soul : MonoBehaviour 
{
    Action callBack;
    [SerializeField] LayerMask mask;
    bool isClick;
    private void Start()
    {
        isClick = false;
    }
    private void OnMouseDown()
    {
        Debug.Log("click");
        this.DOKill();
        StopAllCoroutines();
        isClick = true;
        gameObject.transform.DOLocalMove(new Vector2(-7.3f, 3.2f), 2f).OnComplete(() => {
            StopAllCoroutines();
            callBack?.Invoke();
            gameObject.SetActive(false);
        });
    }
    public void OnSetup(Vector2 startPos, Action callBack = null )
    {
        isClick = false;
        transform.position = new Vector3(startPos.x , startPos.y , 2);
        if(callBack!= null)
        {
            this.callBack = callBack;
        }
        
    }
    public void Move(Vector3 pos)
    {        
        transform.DOLocalMove(pos , 4.5f).OnComplete(() =>
        {
             if(!isClick)
                StartCoroutine(WaitClick());           
        });
    }
    IEnumerator WaitClick()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

   
}
