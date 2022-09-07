using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public Action OnLevelUp;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        //levelConfig = Instantiate(Resources.Load("Config/LevelConfig"
        //    , typeof(ScriptableObject)) as LevelConfig);
    }

    public int level;
    public int currentExp;
    //public LevelConfig levelConfig;

    public int gold;

    public void Init()
    {
       
    }
    //public void AddExp(int exp)
    //{
    //    currentExp +=exp;
    //    if(currentExp> levelConfig.GetExpInLevel(level + 1))
    //    {
    //        currentExp -= levelConfig.GetExpInLevel(level + 1);
    //        level++;
    //        OnLevelUp?.Invoke();
    //    }
    //}

}
