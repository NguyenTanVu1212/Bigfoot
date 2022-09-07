using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb01_AttackState : FSMState
{
    [NonSerialized] public ZbControl_01 parent;
    public Zb01_AttackState(FSMSystem system) : base("atttack", system)
    {
        this.parent = (ZbControl_01)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        if(parent!=null)
        {
            parent.Speed = 0;
        }
        if (parent.hit2D.collider != null)
        {
            parent.dataBinding.Attack = true;
        }

    }
    public override void OnExit()
    {
        base.OnExit();
    }

}

