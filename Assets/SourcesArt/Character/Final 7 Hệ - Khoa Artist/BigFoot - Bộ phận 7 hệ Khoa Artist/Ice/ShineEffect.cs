using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShineEffect : MonoBehaviour
{
    public List<GameObject> shineEffect = new List<GameObject>();
    [SerializeField] float timeEffect;
    float timecount = 0;
    void Start()
    {
        timeEffect = 0.5f;
        foreach (var e in shineEffect)
        {
            e.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timecount>timeEffect)
        {
           int count = Random.Range(1,3);
            for(int i =0; i< count; i++)
            {
                int postion = Random.Range(0 , shineEffect.Count);  
                if(!shineEffect[postion].activeSelf)
                {
                    StartCoroutine(Shine(shineEffect[postion]));
                }
                
            }
            timecount = 0;
        }
        timecount += Time.deltaTime;
    }

    IEnumerator Shine(GameObject shine)
    {
       yield return new WaitForSeconds(0.5f);
       shine.SetActive(true);
       SpriteRenderer sprite = shine.GetComponent<SpriteRenderer>();
       sprite.DOFade(0, 0f).OnComplete(()=> {
           sprite.DOFade(1, 2f).OnComplete(() => {
               sprite.DOFade(0, 1f).OnComplete(() => {
                   shine.SetActive(false);
               });
           });
       });
    }
   
}
