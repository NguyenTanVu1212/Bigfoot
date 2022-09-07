using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    #region SingleTon
    public static PoolObject instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    #region Object Instance
    PoolItems<BulletBehaviour> bulletItem = new PoolItems<BulletBehaviour>("Bullet" , "Bullet",100);
    PoolItems<EnemyBehaviour> enemyitem = new PoolItems<EnemyBehaviour>("Enemy", "Enemy" , 10);
    PoolItems<HeroBehaviour> heroItem = new PoolItems<HeroBehaviour>("Hero/Forest" , "Hero" , 30);
    PoolItems<Soul> soulIteam = new PoolItems<Soul>("Item" , "Soul" , 30);
    #endregion
    #region object Pool
    List<HeroBehaviour> lsHero = new List<HeroBehaviour>();
    List<EnemyBehaviour> lsEnemy = new List<EnemyBehaviour>();
    List<BulletBehaviour> lsbullet = new List<BulletBehaviour>();
    List<Soul> lsSoul = new List<Soul>();
    #endregion
    #region Pool Object
    public GameObject soulPool ;
    public GameObject enemyPool;
    public GameObject heroPool ;
    public GameObject bulletPool;
    #endregion
    List<LevelData> datas = new List<LevelData>();
    public string nameHero = string.Empty;
    private void Start()
    {
        datas = MissionManager.instance.FindDatabyLevel(MissionManager.instance.idLevel);
        bulletItem.LoadResource();
        enemyitem.LoadResource(datas);
        soulIteam.LoadResource();
        soulPool = new GameObject();
        soulPool.name = "Soul Pool :";
        enemyPool = new GameObject();
        enemyPool.name = "Enemy Pool :";
        heroPool = new GameObject();
        heroPool.name = "Hero Pool :";
        bulletPool = new GameObject();
        bulletPool.name = "Bullet Pool :";
        soulPool.transform.SetParent(transform);
        heroPool.transform.SetParent(transform);
        enemyPool.transform.SetParent(transform);
        bulletPool.transform.SetParent(transform);
        CreateSoul();
        CreateBulletObject();
        CraeteEnemy();
    }


    #region Setup
    void CreateBulletObject()
    {
        foreach (var e in bulletItem.lsItems)
        {
            GameObject pool = new GameObject();
            pool.name = "Bullet Pool : " + e.name;
            pool.transform.SetParent(bulletPool.transform);
            for (int i = 0; i < bulletItem.size; i++)
            {
                BulletBehaviour bullet = Instantiate<BulletBehaviour>(e);
                bullet.name = e.name;
                bullet.gameObject.SetActive(false);
                bullet.transform.SetParent(pool.transform);
                lsbullet.Add(bullet);
            }

        }
    }
    void CreateSoul()
    {
        for (int i = 0; i < soulIteam.size; i++)
        {
            Soul soul = Instantiate(soulIteam.lsItems[0]);
            soul.name = "Soul";
            soul.transform.SetParent(soulPool.transform);
            soul.gameObject.SetActive(false);
            lsSoul.Add(soul);
        }
    }
    void CraeteEnemy()
    {
        
        foreach(var e in enemyitem.lsItems)
        {
            GameObject pool = new GameObject();
            pool.name = "Enemy Pool :"  + e.name;
            pool.transform.SetParent(enemyPool.transform);
            for(int i=0; i< enemyitem.size; i++)
            {
                EnemyBehaviour enemy = Instantiate<EnemyBehaviour>(e);
                enemy.name = e.name;
                enemy.gameObject.SetActive(false);
                enemy.transform.SetParent(pool.transform);
                lsEnemy.Add(enemy);
            }
        }
        
    }
    public void CreateHero(List<int> lsId)
    {
        heroItem.LoadResource(lsId);
        foreach (var e in heroItem.lsItems)
        {
            GameObject pool = new GameObject();
            pool.name = "Hero Pool :" + e.name;
            pool.transform.SetParent(heroPool.transform);
            for (int i = 0; i < heroItem.size; i++)
            {
                HeroBehaviour hero = Instantiate<HeroBehaviour>(e);
                hero.name = e.name;
                hero.gameObject.SetActive(false);
                hero.transform.SetParent(pool.transform);
                lsHero.Add(hero);
            }
        }
    }
    #endregion
    #region Call Spam Items
    public BulletBehaviour GetBulletByName(string name)
    {
        foreach (var e in lsbullet)
        {
            if (e.name == name && !e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }
        foreach (var e in lsbullet)
        {
            if (e.name == name)
            {
                BulletBehaviour bullet = Instantiate<BulletBehaviour>(e);
                bullet.name = name;
                lsbullet.Add(bullet);
                bullet.gameObject.SetActive(false);
                for(int i=0; i<bulletPool.transform.childCount;i++)
                {
                    if(bulletPool.transform.GetChild(i).name == "Bullet Pool : " + e.name)
                    {
                        bullet.transform.SetParent(bulletPool.transform.GetChild(i));
                    }
                    else
                    {
                        bullet.transform.SetParent(bulletPool.transform);
                    }
                }
                
                return bullet;
            }
        }
        return null;
    }
    public EnemyBehaviour GetEnemyByName(string name)
    {
        foreach(var e in lsEnemy)
        {
            if(e.name == name && !e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }
        foreach(var e in lsEnemy)
        {
            if(e.name == name)
            {
                EnemyBehaviour enemy = Instantiate<EnemyBehaviour>(e);
                enemy.name = e.name;
                enemy.gameObject.SetActive(false);
                for (int i = 0; i < bulletPool.transform.childCount; i++)
                {
                    if (enemyPool.transform.GetChild(i).name == "Enemy Pool :" + e.name)
                    {
                        enemy.transform.SetParent(enemyPool.transform.GetChild(i));
                    }
                    else
                    {
                        enemy.transform.SetParent(enemyPool.transform);
                    }
                }
                enemy.transform.SetParent(enemyPool.transform);
                lsEnemy.Add(enemy);
                return enemy;
            }
        }
        return null;
    }
    public Soul GetSoulToPool()
    {
        foreach (var e in lsSoul)
        {
            if (!e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }

        Soul newSoul = Instantiate<Soul>(lsSoul[0]);
        newSoul.name = "Soul";
        lsSoul.Add(newSoul);
        newSoul.gameObject.SetActive(false);
        newSoul.transform.SetParent(soulPool.transform);
        return newSoul;
    }
    public HeroBehaviour GetHero()
    {
        foreach (var e in lsHero)
        { 
            if(e.name == nameHero && !e.gameObject.activeInHierarchy)
            {
                return e;
            }
        }
        foreach(var e in lsHero)
        {
            if(e.name == nameHero)
            {
                HeroBehaviour hero = Instantiate<HeroBehaviour>(e);
                hero.name = e.name;
                hero.gameObject.SetActive(false);
                for (int i = 0; i < heroPool.transform.childCount; i++)
                {
                    if (heroPool.transform.GetChild(i).name == "Hero Pool :" + e.name)
                    {
                        hero.transform.SetParent(heroPool.transform.GetChild(i));
                    }
                    else
                    {
                        hero.transform.SetParent(heroPool.transform);
                    }
                }
                lsHero.Add(hero);
                return hero;
            }
        }
        return null; 
    }
    #endregion


}

[System.Serializable]
public class PoolItems<T> 
{
    public List<T> lsItems = new List<T>();
    public string nameTagItems;
    public int size;
    public bool isExpand;
    string path;

    public PoolItems(string path , string nametag , int size)
    {
        this.nameTagItems = nametag;
        this.path = path;
        this.size = size;
        isExpand = true;
    }
    public void LoadResource()
    {
        GameObject[] objs = Resources.LoadAll<GameObject>(path) as GameObject[];
        foreach (var e in objs)
        {
            lsItems.Add(e.GetComponent<T>());
        }
    }
    public void LoadResource(List<LevelData> datas)
    {
        List<int> lsId = new List<int>();
        foreach (var level in datas)
        {
            foreach(var id in level.idEnemy)
            {
                if(!lsId.Contains(id))
                {
                    lsId.Add(id);
                    GameObject obj = Resources.Load(path + "/" + id) as GameObject;
                    lsItems.Add(obj.GetComponent<T>());
                }
            }
        }
    }
    public void LoadResource(List<int> datas)
    {
        foreach(var e in datas)
        {
            GameObject hero = Resources.Load(path+"/" +"Forest_" + (e+1).ToString()) as GameObject;
            lsItems.Add(hero.GetComponent<T>());
        }
       
    }

}