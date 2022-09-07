using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Forest08_Control : HeroBehaviour
{
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);
        idleState = new FSM_Forest08Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest08Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest08OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest08Dead(this);
        AddState(deadState);      
    }
    public override void OnSystemUpdate()
    {
        base.OnSystemUpdate();
    }

    public override void OnSystemFixUpdate()
    {
        base.OnSystemFixUpdate();        
    }
    public override void OnSystemLateUpdate()
    {
        base.OnSystemLateUpdate();

        if (hp <= 0)
        {
            IsDead = true;
        }
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
    public override IEnumerator SpamBullet()
    {
        for(int i=0; i<=1; i++)
        {
            yield return new WaitForSeconds(0.1f);
            BulletBehaviour bullet = PoolObject.instance.GetBulletByName("NormalBullet");
            bullet.transform.position = spamPos.position;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<BulletNormal>().Setup(Vector3.right, 2f, damage, crit, TypeBullet.Normal, timeEffect, rateEffect);
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
