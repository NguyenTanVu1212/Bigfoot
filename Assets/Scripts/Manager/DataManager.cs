using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public HeroConfig heroConfig;
    public EnemyConfig enemyConfig;
    public CardConfig cardConfig;
    //public LevelConfig levelConfig;
    public int idLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        heroConfig = Instantiate(Resources.Load("Config/HeroConfig", typeof(ScriptableObject)) as HeroConfig);
        enemyConfig = Instantiate(Resources.Load("Config/EnemyConfig", typeof(ScriptableObject)) as EnemyConfig);
        cardConfig = Instantiate(Resources.Load("Config/CardConfig", typeof(ScriptableObject)) as CardConfig);
        DontDestroyOnLoad(this);
    }
   
}
