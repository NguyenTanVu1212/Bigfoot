using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : BulletBehaviour
{
    public override void OnSetup()
    {
       
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    public override void OnHitBullet(Collider2D collision)
    {
        GameObject tagert = collision.gameObject;
        if (tagert.CompareTag("Enemy") && tagert.layer == 10 )
        {
            speed = 0;
            float currentDamage = damage;
            if (UnityEngine.Random.Range(0, 100) < this.cirt)
            {
                currentDamage *= 1.5f;
            }
            tagert.GetComponent<EnemyBehaviour>().OnDamage(currentDamage, ()=> 
            {
                //tagert.GetComponent<EnemyBehaviour>().Push(3f , 3f);
            });
            dataBinding.isDestroy = true;     
        }
    }

}
