using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MissionManager : MonoBehaviour
{
    [SerializeField] public static MissionManager instance;
    MissionConfig config;
    public int idLevel;
    [SerializeField] List<List<LevelData>> datas = new List<List<LevelData>>(); 
    private void Awake()
    {
        if (instance == null)
            instance = this;
        config = Instantiate(Resources.Load("Config/MissionConfig",
            typeof(ScriptableObject)) as MissionConfig);
        int counter = -1;
        foreach (var e in config.cf)
        {
            LevelData data = new LevelData();
            data.Setup(e);
            if (data.level == counter)
            {
                datas[data.level].Add(data);
            }
            else
            {
                counter++;
                datas.Add(new List<LevelData>());
                datas[data.level].Add(data);
            }

        }
        DontDestroyOnLoad(this);
    }
    public override string ToString()
    {
        string values = string.Empty;
        foreach (var e in datas)
        {
            foreach (var es in e)
            {
                values += "ID : " + es.id.ToString() + "\n";
                values += "Level : " + es.level.ToString() + "\n";
                values += "Enemy : ";
                foreach(var i in es.idEnemy)
                {
                    if (es.idEnemy.IndexOf(i) == es.idEnemy.Count - 1)
                    {
                        values += i.ToString();
                        break;
                    }
                        
                    values += i.ToString() + ",";
                }
                values += "\n";
                values += "--------------------------------------" + "\n";
            }
        }

        return values;
    }
    public List<LevelData> FindDatabyLevel(int level)
    {
        List<LevelData> data = datas[level];
        return data;
    }
    public void ChoseLevel(int id)
    {
        this.idLevel = id;
    }

}
[Serializable]
public class LevelData
{
    public int level;
    public int id;
    public List<int> idEnemy = new List<int>();
    public List<float> rateSpameEnemy = new List<float>();
    public List<int> totalEnemyInTurn = new List<int>();
    public float timeInturn;
    public int totalTurn;
    public void Setup(MissionConfigData data)
    {
        level = data.Level;
        id = data.Id;
        foreach (var e in data.IdEnemy.Split(','))
        {           
            idEnemy.Add(int.Parse(e));
        }
        foreach (var e in data.Rate.Split(','))
        {
            rateSpameEnemy.Add(float.Parse(e));
        }
        foreach (var e in data.EnemyInTurn.Split(','))
        {
            totalEnemyInTurn.Add(int.Parse(e));
        }
        timeInturn = data.TimeInTurn;
        totalTurn = data.TotalTurn;
    }
}

