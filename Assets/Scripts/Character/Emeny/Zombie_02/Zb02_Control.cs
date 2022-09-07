using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Zb02_Control : EnemyBehaviour
{
    float timeSkill;
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
        timeSkill = 5f;
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
        timeSkill = 5f;
    }

    public override void OnSystemUpdate()
    {
        if (timeSkill >= 0)
        {
            Speed = data.Speed * 2;
            isDebuff = true;
        }
        else if(timeSkill<0 && isDebuff )
        {
            isDebuff = false;
            Speed = data.Speed;
        }
        base.OnSystemUpdate();
    }
    public override void OnSystemLateUpdate()
    {
        timeSkill -= Time.deltaTime;
        base.OnSystemLateUpdate();
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
    public override void OnDamage(float damage ,Action callBack )
    {
        base.OnDamage(damage , callBack);        
    }
    public override void OnDead()
    {
        
        base.OnDead();

    }
    public override IEnumerator DestroyZombie()
    {
        yield return new WaitForSeconds(0f);
        if (!isHypnosis)
        {
            EnemyManager.instance.counter--;
        }
        gameObject.SetActive(false);
    }

}
