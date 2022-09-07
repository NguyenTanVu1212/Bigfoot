using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZbControl_01 : EnemyBehaviour
{
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);
        idleState = new Zb01_IdleState(this);
        AddState(idleState);
        attackState = new Zb01_AttackState(this);
        AddState(attackState);
        deadState = new Zb01_DeadState(this);
        AddState(deadState);
        moveState = new Zb01_MoveState(this);
        AddState(moveState);
        GotoState(idleState);
        Speed = this.data.Speed;
    }
    public override void OnSetup()
    {
        base.OnSetup();
        idleState = new Zb01_IdleState(this);
        AddState(idleState);
        attackState = new Zb01_AttackState(this);
        AddState(attackState);
        deadState = new Zb01_DeadState(this);
        AddState(deadState);
        moveState = new Zb01_MoveState(this);
        AddState(moveState);
        GotoState(idleState);
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
    public override void OnDamage(float damage , Action callBack)
    {
        base.OnDamage(damage, callBack);
    }
    public override void OnDead()
    {
        base.OnDead();        
    }
    
   
}
