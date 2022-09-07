using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataBinding : MonoBehaviour
{
    public Animator animator;

    private int AnimKeyIsDestroy;

    public bool isDestroy
    {
        set {
            if(value)
            {
                animator.SetTrigger(AnimKeyIsDestroy);
            }
        }
    }

    private void Awake()
    {
        if(animator== null)
        {
            animator = GetComponent<Animator>();
        }
        AnimKeyIsDestroy = Animator.StringToHash("Destroy");
    }
   
}
