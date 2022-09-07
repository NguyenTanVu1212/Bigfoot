using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyConfig : ReadCSV<EnemyConfigData>
{
    EnemyConfigData datas = new EnemyConfigData();
    [SerializeField] List<EnemyConfigData> cf = records;

    public EnemyConfigData FindById(int id)
    {
        foreach(var e in cf)
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
public class EnemyConfigData
{
    public int Id { get => id; set => id = value; }
    public string NameEnemy { get => nameEnemy; set => nameEnemy = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Rof { get => rof; set => rof = value; }
    public int Level { get => level; set => level = value; }
    public string TypeEnemy { get => typeEnemy; set => typeEnemy = value; }

    [SerializeField]
    private int id;
    [SerializeField]
    private string nameEnemy;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rof;
    [SerializeField]
    private int level;
    [SerializeField] 
    private string typeEnemy;
}
