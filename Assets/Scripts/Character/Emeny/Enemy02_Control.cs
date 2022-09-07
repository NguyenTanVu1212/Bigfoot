using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy02_Control : EnemyBehaviour
{
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
        Speed = this.data.Speed;
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
    public override void OnDamage(float damage, Action callBack)
    {
        base.OnDamage(damage, callBack);
    }
    public override void OnDead()
    {

        base.OnDead();

    }
    public override IEnumerator DestroyZombie()
    {
        SpamEnemy(9, 2);
        if (!isHypnosis)
        {
            EnemyManager.instance.counter--;
        }
        gameObject.SetActive(false);               
        yield return null;
    }

}
