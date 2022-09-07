using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Forest03_Control : HeroBehaviour
{
    [SerializeField] GameObject soul;
    
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);
        idleState = new FSM_Forest03Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest03Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest03OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest03Dead(this);
        AddState(deadState);
    }
    public override void OnSystemUpdate()
    {
        if (timeCount <= 0)
        {
            GotoState(attackState);
        }
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
    public override IEnumerator SpamBullet()
    {
        for(int i= 0; i<= 1; i++)
        {
            Soul goldClone = PoolObject.instance.GetSoulToPool();
            
            goldClone.GetComponent<Soul>().OnSetup(gameObject.transform.position, () =>
            {
                SoulManager.instance.AddSoul();
            });
            goldClone.gameObject.SetActive(true);
            goldClone.GetComponent<Soul>().Move(new Vector2(transform.position.x, transform.position.y - 2f));
            yield return new WaitForSeconds(0.5f);
        }
    }
    public override void OnDamage(float damage, Action callback)
    {
        base.OnDamage(damage, callback);
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
