using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConfig : ReadCSV<CardConfigData>
{
    CardConfigData datas = new CardConfigData();
    [SerializeField] List<CardConfigData> cf = records;

    public CardConfigData FindById(int id)
    {
        foreach (var e in cf)
        {
            if (id == e.id)
            {
                datas = e;
                break;
            }
            else datas = null;
        }
        return datas;
    }
}

[System.Serializable] 
public class CardConfigData
{
    public int id;
    public string name;
    public float timeReload;
    public int cost;
    public string explain;
}