                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HeroBehaviour : FSMSystem
{
    #region 
    public Transform myTransform;
    [SerializeField] public Transform spamPos;
    public HeroDataBinding dataBinding;
    public bool isAttack;
    public FSMState idleState;
    public FSMState attackState;
    public FSMState onHitState;
    public FSMState deadState;
    public float timeCount;
    public bool isDead = false;
    public bool isOnDamage = false;
    public bool hasEnemyInRange;
    public float hp;
    public float damage;
    public float rof;
    public float crit;
    public float timeEffect;
    public float rateEffect;
    public LayerMask mask;
    #endregion
    #region Setup
    void InitData(HeroConfigData data)
    {
        hp = data.Hp;
        damage = data.Damage;
        rof = data.Rof;
        crit = data.Crit;
        timeEffect = data.TimeEffect;
        rateEffect = data.RateEffect;
    }
    public virtual void OnSetup(object dataInit)
    {
        InitData((HeroConfigData)dataInit);
        timeCount = 0;
        
        IsDead = false;
        IsOnDamage = false;
        HasEnemyInRange = false;
    }
    #endregion
    #region State Control
    public bool HasEnemyInRange
    {
        get => hasEnemyInRange;
        set
        {
            if (value)
            {
                GotoState(attackState);
            }
            hasEnemyInRange = value;
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
    public bool IsOnDamage
    {
        get
        {
            return isOnDamage;
        }
        set
        {
            if (value)
            {
                GotoState(onHitState);
            }
            isOnDamage = value;
        }
    }
    #endregion
    #region System
    private void Awake()
    {
        myTransform = transform;
    }
    public override void OnSystemLateUpdate()
    {
        base.OnSystemLateUpdate();
        if (hp <= 0)
        {
            IsDead = true;
        }
    }
    public override void OnSystemStart()
    {
        base.OnSystemStart();
    }
    public override void OnSystemFixUpdate()
    {
        base.OnSystemFixUpdate();
        timeCount -= Time.fixedDeltaTime;
    }
    public override void OnSystemUpdate()
    {
        base.OnSystemUpdate();
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, 15f, mask);
        if (hit2D.collider != null)
        {

            if (hit2D.collider.CompareTag("Enemy"))
            {
                HasEnemyInRange = true;
            }
            else GotoState(idleState);
        }
    }
    #endregion
    #region Hero Action
    public virtual void OnDamage(float damage, Action callback)
    {
        hp -= damage;
        callback?.Invoke();
    }
    public virtual void OnAttack()
    {
        timeCount = rof;
    }
    public virtual void OnDead()
    {

    }
    public virtual void DestroyHero()
    {
        Destroy(gameObject);
    }
    public virtual IEnumerator SpamBullet()
    {
        yield return new WaitForSeconds(0.1f);        
    }

    #endregion
}
