using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Forest07_Control : HeroBehaviour
{
   
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);       
        idleState = new FSM_Forest07Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest07Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest07OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest07Dead(this);
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
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
    public override IEnumerator SpamBullet()
    {
        yield return new WaitForSeconds(0.1f);
        BulletBehaviour bullet = PoolObject.instance.GetBulletByName("IceBullet");
        bullet.transform.position = spamPos.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<BulletFreeze>().Setup(Vector3.right, 2f, damage,crit, TypeBullet.Normal, timeEffect , rateEffect);
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
