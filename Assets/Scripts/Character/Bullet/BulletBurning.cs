using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBurning : BulletBehaviour
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
            float curentDamage =0f;
            if (UnityEngine.Random.Range(0, 100) < this.cirt)
            {
                curentDamage = damage * 1.5f;
            }
            else curentDamage = damage;
            tagert.GetComponent<EnemyBehaviour>().OnDamage(curentDamage, () =>
            {
               
            });
            dataBinding.isDestroy = true;
        }
    }
}
