using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.EventSystems;
public class CardObject : MonoBehaviour , IDragHandler , IPointerDownHandler , IPointerUpHandler
{
    [SerializeField] GameObject icon;
    [SerializeField] Image iconImage;
    [SerializeField] Text costText;
    //[SerializeField] Button btn_click;
    //[SerializeField] Image reloadImage;
    [SerializeField] private int cost;
    private int id;
    private float timeReload;
    public bool isBuy = true;
    GameObject iconDraw;
    
    
    //bool isReload = false;

    // Start is called before the first frame update
    public void OnSetup(CardConfigData data , Action callBack)
    {
        this.costText.text = data.cost.ToString();
        cost = data.cost;
        id = data.id;
        timeReload = data.timeReload;
        //reloadImage.color = new Color(1,1,1,0);
        string path = "UI/Icon/Hero/Forest " + (id + 1).ToString();
        iconImage.sprite = Resources.Load(path , typeof(Sprite)) as Sprite;
        iconDraw = Instantiate(iconImage.gameObject, gameObject.transform);
        iconDraw.transform.eulerAngles = Vector2.Lerp(transform.eulerAngles , transform.eulerAngles + 180f * Vector3.up, 1f);
        iconDraw.SetActive(false);
        callBack?.Invoke();
    }
    private void Start()
    {
        if (cost <= SoulManager.instance.totalSoul)
        {
            isBuy = true;
        }
        else isBuy = false;
    }
    private void Update()
    {
        if (cost <= SoulManager.instance.totalSoul)
        {
            isBuy = true;
        }
        else
        {          
            isBuy = false;
        }
       
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isBuy) return;
        iconDraw.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isBuy)
        {
            StartCoroutine(SoulManager.instance.ChangeTextColor());
            return;
        }
        iconDraw.SetActive(true);
        
        iconDraw.transform.position = Input.mousePosition;
        if (PoolObject.instance.nameHero == string.Empty)
        {
            PoolObject.instance.nameHero = "Forest_" + (id + 1).ToString();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isBuy) 
        {           
            return;
        };
        iconDraw.SetActive(false);
        BoardManager.callBack = () =>
        {
            SoulManager.instance.OnUsedSoul(cost);
        };
        
     
    }
}
