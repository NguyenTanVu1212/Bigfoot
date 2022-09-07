using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabinding : MonoBehaviour
{
    public Animator animator;
    private int AnimkeyDead;
    private int AnimkeyAtack;
    private int AnimkeyOnHit;
    private int AnimkeyMove;
    private void Awake()
    {
        if (animator == null)
            GetComponent<Animator>();
        AnimkeyAtack = Animator.StringToHash("Attack");
        AnimkeyDead = Animator.StringToHash("Dead"); 
        AnimkeyMove = Animator.StringToHash("Speed");
        AnimkeyOnHit = Animator.StringToHash("Onhit");
    }

    public bool Attack
    {
        set
        {
           
            animator.SetTrigger(AnimkeyAtack);
            
        }
    }
    public bool Dead
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(AnimkeyDead);
            }
        }
    }
    public bool Onhit
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(AnimkeyOnHit);
            }
        }
    }

    public float Speed
    {
        set
        {
            if(animator.gameObject.activeSelf)
            {
                animator.SetFloat(AnimkeyMove, value);
            }
                    
        }
    }
}
