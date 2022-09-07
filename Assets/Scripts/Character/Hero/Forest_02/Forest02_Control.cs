using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Forest02_Control : HeroBehaviour
{ 
    public override void OnSetup(object dataInit)
    {
        base.OnSetup(dataInit);       
        idleState = new FSM_Forest02Idle(this);
        AddState(idleState);
        attackState = new FSM_Forest02Attack(this);
        AddState(attackState);
        onHitState = new FSM_Forest02OnHit(this);
        AddState(onHitState);
        deadState = new FSM_Forest02Dead(this);
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
    public override void DestroyHero()
    {
        base.DestroyHero();
    }
    public override IEnumerator SpamBullet()
    {
        BulletBehaviour bullet = PoolObject.instance.GetBulletByName("NormalBullet");
        bullet.transform.position = spamPos.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<BulletNormal>().Setup(Vector3.right, 2f, damage,crit, TypeBullet.Normal , timeEffect , rateEffect);
        return base.SpamBullet();
    }
    public override void OnDamage(float damage, Action callback)
    {
        base.OnDamage(damage, callback);
    }

    public override void OnDead()
    {
        base.OnDead();
    }
   
}
