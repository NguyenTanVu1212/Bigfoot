using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<LevelData> datas = new List<LevelData>();
    public List<EnemyBehaviour> lsEnemy = new List<EnemyBehaviour>();
    public List<Transform> lsPos = new List<Transform>();
    public List<GameObject> totalEnemy = new List<GameObject>();
    public int counter = 0;
    public int totalEnemyReSpam = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void Start()
    {
        datas = MissionManager.instance.FindDatabyLevel(MissionManager.instance.idLevel);
        List<int> idEnemy = new List<int>();
        foreach(var e in datas)
        {           
            foreach(var i in e.totalEnemyInTurn)
            {
                counter += i;
            }
        }
    }
    private void Update()
    {
        if (counter <= 0)
            GameManger.instance.isWin = true;
    }
    public IEnumerator SpamEnemy(LevelData leveldata , System.Action callback)
    {       
        foreach(var e in leveldata.totalEnemyInTurn)
        {
            yield return new WaitForSeconds(leveldata.timeInturn);
            for (int i =0; i<e; i++)
            {
                int idRandom = RandomEnemy(leveldata.idEnemy, leveldata.rateSpameEnemy);
                EnemyBehaviour spameEnemy = PoolObject.instance.GetEnemyByName(idRandom.ToString());
                spameEnemy.transform.position = lsPos[Random.Range(0,3)].position;
                EnemyConfigData data = DataManager.instance.enemyConfig.FindById(idRandom - 1);
                spameEnemy.OnSetup(data);
                spameEnemy.gameObject.SetActive(true);
                totalEnemy.Add(spameEnemy.gameObject);
                totalEnemyReSpam++;
            }
        }
        callback?.Invoke();
    }   
    public int RandomEnemy(List<int> idEnemy , List<float> rate)
    {
        float sumRate = 0;
        foreach(var e in rate)
        {
            sumRate += e;
        }
        float rand = UnityEngine.Random.Range(0, sumRate);
        for (int i=0; i< idEnemy.Count; i++)
        {        
            if(rand <= rate[i])
            {
                return idEnemy[i];

            }else
            {
                rand -= rate[i];
            }
        }
        return idEnemy[-1];
    }
    public void StartSpamEnemy()
    {
        int state = 0;
        StartCoroutine(SpamEnemy(datas[state], () => {
            state++;
            StartCoroutine(SpamEnemy(datas[state], () => {
                state++;
                StartCoroutine(SpamEnemy(datas[state], () =>
                {
                }));
            }));
        }));
    }
}
