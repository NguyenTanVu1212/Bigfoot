using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionConfig : ReadCSV<MissionConfigData>
{
    MissionConfigData datas = new MissionConfigData();
    [SerializeField] public List<MissionConfigData> cf = records;

    public MissionConfigData FindDataById(int id)
    {
        foreach (var e in cf)
        {
            if (id == e.Id)
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
public class MissionConfigData
{
    public int Id;
    public int Level;
    public string IdEnemy;
    public string Rate;
    public int TotalTurn;
    public string EnemyInTurn;
    public float TimeInTurn;
}
