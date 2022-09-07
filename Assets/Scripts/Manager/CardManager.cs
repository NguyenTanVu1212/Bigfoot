using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public List<int> idCard = new List<int>();
    List<GameObject> lsCard = new List<GameObject>();
    [SerializeField] GameObject parent;
    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }
    [SerializeField]GameObject cardobject;

    private void Start()
    {
         
    }
    public void CreateListCard()
    {
        foreach (var e in idCard)
        {
            GameObject card = Instantiate(cardobject, parent.transform);
            card.GetComponent<CardObject>().OnSetup(DataManager.instance.cardConfig.FindById(e), () => { });
            lsCard.Add(card);
        }
    }
}
