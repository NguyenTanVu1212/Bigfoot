using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class EnemyBehaviour : FSMSystem
{
    #region 
    [SerializeField]
    public EnemyConfigData data = new EnemyConfigData();
    [SerializeField]
    List<SpriteRenderer> bodyPart = new List<SpriteRenderer>();
    public EnemyDatabinding dataBinding;
    protected float hp, damage, speed, rof;
    public float timeDebuff;
    public float timeSlow;
    public float timeStun;
    public bool isDebuff;
    public LayerMask tagertMask;
    public string tagertTag;
    public float timeCount;
    public bool isDead = false;
    public bool isAttack;
    public Vector2 dir;
    public RaycastHit2D hit2D;
    [SerializeField]
    public FSMState attackState;
    [SerializeField]
    public FSMState idleState;
    [SerializeField]
    public FSMState moveState;
    [SerializeField]
    public FSMState deadState;
    public bool isHypnosis;
    public bool isSlow;
    public bool isStun;
    #endregion
    #region Setup
    void InitData(EnemyConfigData dataInit)
    {
        this.data = dataInit;
        hp = data.Hp;
        damage = data.Damage;
        speed = data.Speed;
        rof = data.Rof;
        timeCount = data.Rof;
    }

    public virtual void OnSetup()
    {
        data = DataManager.instance.enemyConfig.FindById(0);
        hp = data.Hp;
        damage = data.Damage;
        speed = data.Speed;
        rof = data.Rof;
        isDead = false;
        timeCount = this.data.Rof;
        timeDebuff = -1;
        isAttack = true;
        tagertTag = "Hero";
        dir = Vector2.left;
        isHypnosis = false;
        isSlow = false;
        isStun = false;
        tagertMask = LayerMask.GetMask("Hero");
        isDebuff = false;
    }
    public virtual void OnSetup(object dataInit)
    {
        InitData((EnemyConfigData)dataInit);
        isDead = false;
        timeDebuff = -1;
        isAttack = true;
        tagertTag = "Hero";
        dir = Vector2.left;
        isHypnosis = false;
        isSlow = false;
        isStun = false;       
        tagertMask = LayerMask.GetMask("Hero");
        isDebuff = false;
    }
    #endregion
    #region Enemy Action
    public virtual IEnumerator DestroyZombie()
    {    
        if(!isHypnosis)
        {
            EnemyManager.instance.counter--;
        }
        gameObject.SetActive(false);
        yield return null;
    }
    public virtual void OnDamage(float damage, Action callBack)
    {
        hp -= damage;
        //StartCoroutine(OnHit());
        callBack?.Invoke();
        if (isStun || isSlow)
            return;
        //StartCoroutine(OnHit());
    }
    public virtual void OnAttack()
    {
        timeCount = rof;
        if (hit2D.collider != null)
        {
            if(hit2D.collider.tag=="Enemy")
            {
                hit2D.collider.gameObject.GetComponent<EnemyBehaviour>().OnDamage(damage, () => { });
            }
            else if(hit2D.collider.tag == "Hero")
            {
                hit2D.collider.gameObject.GetComponent<HeroBehaviour>().OnDamage(damage, () => { });
            }
        }
        isAttack = true;
        if(!CheckInRange())
        {
            if (isSlow || isStun)
            {
                return;
            }
            Speed = data.Speed;
        }else
        {
            if (isSlow || isStun)
            {
                return;
            }
            Speed = 0;
        }
    }
    public virtual void OnDead()
    {
        if (IsDead) return;
        IsDead = true;
    }
    public float Speed
    {
        get => speed;
        set
        {
            if (value >= 0.5f)
            {
                GotoState(moveState);
            }
            else if( value < 0.5f)
            {
                GotoState(idleState);
            }
            speed = value;
        }
    }
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            if (value)
            {
                GotoState(deadState);
            }
            isDead = value;
        }
    }
    public virtual IEnumerator OnHit()
    {
        foreach (var e in bodyPart)
        {
            e.color = new Color(0.8f, 0.8f, 0.8f, 0.8f);
        }
        yield return new WaitForSeconds(0.2f);
        foreach (var e in bodyPart)
        {
            e.color = new Color(1f, 1, 1, 1f);
        }
    }
    public virtual void CheckLive()
    {
        if (hp <= 0)
        {
            OnDead();
        }
    }
    #endregion
    #region System 
    private void Awake()
    {
        
    }
    public override void OnSystemLateUpdate()
    {
        base.OnSystemLateUpdate();
        timeCount -= Time.fixedDeltaTime;
        CheckLive();
        if(timeSlow<= 0 && isSlow)
        {
            timeSlow = 0;
            isSlow = false;
            EndSlow();
        }
        if (timeStun <= 0 && isStun)
        {
            timeStun = 0;
            isStun = false;
            EndStun();
        }
    }
    public override void OnSystemUpdate()
    {
        base.OnSystemUpdate();      
        if(timeStun >0 && isStun)
        {
            timeStun -= Time.deltaTime;
        }
        if (timeSlow > 0 && isSlow)
        {
            timeSlow -= Time.deltaTime;
        }
        if (!isAttack) return;
        if (timeCount < 0)
        {
            if (isStun) return;
            hit2D = Physics2D.Raycast(transform.position, Vector2.left, 1f, tagertMask);
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Enemy") || hit2D.collider.CompareTag("Hero"))
                {
                    Speed = 0;
                    GotoState(attackState);
                    isAttack = false;
                }

            }
        }
        if(transform.position.x >=12)
        {
            IsDead = true;
        }
    }

    bool CheckInRange()
    {
        hit2D = Physics2D.Raycast(transform.position, Vector2.left, 01f, tagertMask);
        {
            if (hit2D.collider != null) return true; 

        }
        return false;
    }
    #endregion
    #region Debuff action
    public void EndDebuff()
    {
        Speed = data.Speed;
        isSlow = isStun = false;
        foreach (var e in bodyPart)
        {
            e.color = new Color(1, 1, 1, 1);
        }
    }
    void EndSlow()
    {
        
        if (isStun) return;
        Speed = data.Speed;
        foreach (var e in bodyPart)
        {
            e.color = new Color(1f, 1, 1, 1);
        }
        isSlow = false;
    }
    void EndStun()
    {
        Speed = data.Speed;
        isAttack = true;
        foreach (var e in bodyPart)
        {
            e.color = new Color(1f, 1, 1, 1);
        }
        isStun = false;
    }
    public void Slow(float timeDebuff , float rateEffect)
    {
        if (isDebuff) return;
        if (isStun) return;
        isSlow = true;
        timeSlow = timeDebuff;
        foreach (var e in bodyPart)
        {
            e.color = new Color(0,0.8f, 1, 1);
        }
        Speed = data.Speed * (rateEffect/100);
    }
    public void Stun(float timeDebuff)
    {
        if (isDebuff) return;
        isStun = true;
        if(isSlow)
        {
            EndSlow();
            timeStun = timeDebuff * 0.3f;
        }
        else
        {
            timeStun = timeDebuff;
        }

        foreach (var e in bodyPart)
        {
            e.color = new Color(1f, 1, 1, 1);
        }
        Speed = 0f;
        isAttack = false;
    }
    public void Hypnosis()
    {
        if (isDebuff) return;
        if (isHypnosis) return;
        isHypnosis = true;
        this.Speed = data.Speed;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + 180f * Vector3.up, 1f);
        tagertMask = LayerMask.GetMask("Enemy");
        tagertTag = "Enemy";
        //gameObject.tag = "Hero";
        gameObject.layer = (int)8;
        EnemyManager.instance.counter--;
        foreach(var e in bodyPart)
        {
            e.color = new Color(0.6f,1,1,1);
        }
    }
    public void Endhypnosis()
    {
        // 
    }
    public void Push(float distance , float time)
    {
        if (isDebuff) return;
        transform.DOMoveX(transform.position.x + distance, distance);
    }
    #endregion
    #region skill
    protected void SpamEnemy(int id , int amount)
    {
        EnemyManager.instance.counter += amount;
        for(int i = 0; i< amount; i++)
        {
            EnemyBehaviour enemy = Instantiate(Resources.Load("Enemy/" + id , typeof(EnemyBehaviour)) as EnemyBehaviour );
            Vector2 possion = new Vector2(transform.position.x + UnityEngine.Random.Range(-2,2), transform.position.y);
            enemy.transform.position = possion;
            enemy.speed = enemy.data.Speed * 3f;
            enemy.OnSetup(DataManager.instance.enemyConfig.FindById(id-1));
        }
    }
    #endregion
}