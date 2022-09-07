using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb05_AttackState : FSMState
{
    [NonSerialized] Zb05_Control parent;
    public Zb05_AttackState(Zb05_Control control) : base("attack", control)
    {
        this.parent = control;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Attack = true;

    }
}
