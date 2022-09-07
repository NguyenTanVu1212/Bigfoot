using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
public class CardDemo : MonoBehaviour
{
    [SerializeField] GameObject icon;
    [SerializeField] Image iconImage;
    [SerializeField] private int cost;
    [SerializeField] Text costText;
    public Button btn_CardClick;
    public TextMeshProUGUI tetxBtn;
    public GameObject touchPanel;
    public Action OnClick;
         
    public int id;
    private float timeReload;
    public void OnSetup(CardConfigData data, Action callBack)
    {
        IsSeclect = false;
        cost = data.cost;
        id = data.id;
        this.costText.text = cost.ToString();
        timeReload = data.timeReload;
        //reloadImage.color = new Color(1,1,1,0);
        string path = "UI/Icon/Hero/Forest " + (id + 1).ToString();
        iconImage.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        touchPanel.SetActive(false);
        callBack?.Invoke();
       
    }
    private void Start()
    {
        touchPanel.SetActive(false);
    }
    private void Update()
    {
       
    }
    public void AddActionButton(Action callback)
    {
        OnClick += callback;
        btn_CardClick.onClick.AddListener(() => 
        {
            OnClick?.Invoke();
            
        });
        touchPanel.SetActive(true);
    }
    private bool isSelect;
    public bool IsSeclect
    {
        get
        {
            return isSelect;
        }
        set
        {
            if(value)
            {
                tetxBtn.text = "Remove";
                btn_CardClick.image.color = Color.red;
            }else
            {
                tetxBtn.text = "Select";
                btn_CardClick.image.color = Color.green;
            }
        }
    }

   
}
