using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Forest04_Control : HeroBehaviour
{
    [SerializeField] GameObject soul;
  
    

    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);
        idleState = new FSM_Forest04Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest04Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest04OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest04Dead(this);
        AddState(deadState);
    }
    public override void OnSystemUpdate()
    {
        if(timeCount <= 0)
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
        Soul goldClone = PoolObject.instance.GetSoulToPool();
        goldClone.gameObject.SetActive(true);
        goldClone.GetComponent<Soul>().OnSetup(gameObject.transform.position, () =>
        {
           SoulManager.instance.AddSoul();
        });
        goldClone.GetComponent<Soul>().Move(new Vector2(transform.position.x, transform.position.y - 2f));
        yield return null;
    }
    public override void OnDamage(float damage, Action callback)
    {
        base.OnDamage(damage, callback);
    }

    public override void OnDead()
    {
        base.OnDead();
    }
    public void OnMouseDown()
    {
        Soul goldClone = PoolObject.instance.GetSoulToPool();
        goldClone.gameObject.SetActive(true);
        goldClone.GetComponent<Soul>().OnSetup(gameObject.transform.position, () =>
        {
            SoulManager.instance.AddSoul();
        });
        goldClone.GetComponent<Soul>().Move(new Vector2(transform.position.x, transform.position.y - 2f));
    }
    public override void DestroyHero()
    {
        base.DestroyHero();
    }
}
