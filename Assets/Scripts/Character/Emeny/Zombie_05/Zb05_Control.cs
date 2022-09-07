using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Zb05_Control : EnemyBehaviour
{
    int turnLive;
    [SerializeField]
    ParticleSystem healingEffetc;
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);        
        idleState = new Zb02_IdleState(this);
        AddState(idleState);
        attackState = new Zb02_AttackState(this);
        AddState(attackState);
        deadState = new Zb02_DeadState(this);
        AddState(deadState);
        moveState = new Zb02_WalkState(this);
        AddState(moveState);
        GotoState(idleState);
        Speed = this.data.Speed;
    }
    public override void OnSetup()
    {
        base.OnSetup();
        idleState = new Zb02_IdleState(this);
        AddState(idleState);
        attackState = new Zb02_AttackState(this);
        AddState(attackState);
        deadState = new Zb02_DeadState(this);
        AddState(deadState);
        moveState = new Zb02_WalkState(this);
        AddState(moveState);
        GotoState(idleState);
        Speed = this.data.Speed;

    }
    public override void OnSystemStart()
    {
        base.OnSystemStart();
        turnLive = 2;
        
        healingEffetc.Stop(true , ParticleSystemStopBehavior .StopEmittingAndClear);

    }
    public override void OnSystemUpdate()
    {        
        base.OnSystemUpdate();        
    }
    public override void OnSystemLateUpdate()
    {
        base.OnSystemLateUpdate();

    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
    public override void OnDamage(float damage , Action callBack)
    {
        base.OnDamage(damage , callBack);
    }
    public override void OnDead()
    {
        base.OnDead();
    }

    public override IEnumerator DestroyZombie()
    {
        
            turnLive -= 1;
            if (turnLive >= 1)
            {
                gameObject.tag = "Dead Body";
                StartCoroutine(RevivalSkill());
            }
            else if (turnLive < 1)
            {
                yield return null;
            if(!isHypnosis)
            {
                EnemyManager.instance.counter--;
            }
            gameObject.SetActive(false);
            }       
    }
    IEnumerator RevivalSkill()
    {
        this.Speed = 0;
        healingEffetc.Play(false);
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Enemy";
        IsDead = false;
        this.GotoState(idleState);
        //EnemyConfigData data = DataManager.instance.enemyConfig.FindById(this.data.Id);
        this.OnSetup(DataManager.instance.enemyConfig.FindById(this.data.Id));
        this.hp = this.data.Hp * 0.8f;
        this.Speed = this.data.Speed * 5f;
        healingEffetc.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

    }
}
