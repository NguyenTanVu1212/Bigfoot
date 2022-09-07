using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Shove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject shove;
    [SerializeField] LayerMask mask;
    GameObject shoveDraw;
    void Start()
    {
        shoveDraw = Instantiate(shove , gameObject.transform);
        shoveDraw.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        shoveDraw.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        shoveDraw.SetActive(true);
        shoveDraw.transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shoveDraw.SetActive(false);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(mousePos, Vector2.zero,0, mask);
        if (hit2D.collider != null)
        {

            if (hit2D.collider.CompareTag("Hero"))
            {
                Destroy(hit2D.collider.gameObject);
            }
        }
    }
}
