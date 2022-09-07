using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDataBinding : MonoBehaviour
{
    public Animator animator;
    private int AnimkeyDead;
    private int AnimkeyAttack;
    private int AnimkeyOnHit;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        AnimkeyDead = Animator.StringToHash("Dead");
        AnimkeyAttack = Animator.StringToHash("Attack");
        AnimkeyOnHit = Animator.StringToHash("OnHit");
    }
    public bool Attack
    {
        set {
            if (value)
            {
                animator.SetTrigger(AnimkeyAttack);
            }
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
}
