using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroConfig : ReadCSV<HeroConfigData>
{
    HeroConfigData datas = new HeroConfigData();
    [SerializeField] public List<HeroConfigData> cf = records;
    public HeroConfigData FindDataById(int id)
    {
        foreach (var e in records)
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
    public HeroConfigData FindDataByName(string name)
    {
        foreach (var e in records)
        {
            if (name == e.NameHero)
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
public class HeroConfigData 
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string nameHero;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float rof;
    [SerializeField]
    private int level;
    [SerializeField]
    private float crit;
    [SerializeField]
    private float timeEffect;
    [SerializeField]
    private float rateEffect;

    public int Id { get => id; set => id = value; }
    public string NameHero { get => nameHero; set => nameHero = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Rof { get => rof; set => rof = value; }
    public int Level { get => level; set => level = value; }
    public float Crit { get => crit; set => crit = value; }
    public float TimeEffect { get => timeEffect; set => timeEffect = value; }
    public float RateEffect { get => rateEffect; set => rateEffect = value; }
}
