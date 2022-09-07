using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Forest06_Control : HeroBehaviour
{
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);      
        idleState = new FSM_Forest06Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest06Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest06OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest06Dead(this);
        AddState(deadState);        
    }
    public override void OnSystemUpdate()
    {
    }

    public override void OnSystemFixUpdate()
    {
        base.OnSystemFixUpdate();
    }
    public override void OnSystemLateUpdate()
    {
        base.OnSystemLateUpdate();
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
    
    public override void OnDamage(float damage, Action callback)
    {
        hp -= damage * 0.5f;
        callback?.Invoke();
    }

    public override void OnDead()
    {
        base.OnDead();
    }
    public override void DestroyHero()
    {
        base.DestroyHero();
    }
}
