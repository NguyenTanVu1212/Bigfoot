using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb02_AttackState : FSMState
{
    [NonSerialized] public EnemyBehaviour parent;
    public Zb02_AttackState(FSMSystem control) : base("attack", control)
    {
        this.parent = (EnemyBehaviour)control;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (parent != null)
        {
            parent.Speed = 0;
        }
        if (parent.hit2D.collider != null)
        {
            parent.dataBinding.Attack = true;
        }

    }
}
