using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] LayerMask mask;
    public static Action callBack;
    int cost;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos , Vector2.zero , mask);
            if(hit2D.collider!= null)
            {
                if(hit2D.collider.CompareTag("Board"))
                {
                    if (hit2D.collider.gameObject.GetComponent<CellManager>().isNull)
                    {
                        if (PoolObject.instance.nameHero!= string.Empty)
                        {
                            HeroBehaviour hero = PoolObject.instance.GetHero();
                            hero.GetComponent<HeroBehaviour>().OnSetup(DataManager.instance.heroConfig.FindDataByName(hero.name));
                            hero.transform.position = hit2D.collider.gameObject.GetComponent<CellManager>().pos.position;
                            hit2D.collider.gameObject.GetComponent<CellManager>().isNull = true;
                            hero.gameObject.SetActive(true);
                            hit2D.collider.gameObject.GetComponent<CellManager>().isNull = false;
                            callBack?.Invoke();
                            callBack = null;
                        }
                    }              
                }
            }
            PoolObject.instance.nameHero = string.Empty;
        }
    }
}
