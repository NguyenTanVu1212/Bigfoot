using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFreeze : BulletBehaviour
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
        if (tagert.CompareTag("Enemy") && tagert.layer == 10)
        {
            speed = 0;
            tagert.GetComponent<EnemyBehaviour>().OnDamage(damage, () =>
            {
                if (UnityEngine.Random.Range(0, 100) < this.cirt)
                {
                    tagert.GetComponent<EnemyBehaviour>().Stun(timeEffect);
                }
              
            });
            dataBinding.isDestroy = true;
        }
    }
}
