using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb05_DeadState : FSMState
{
    [NonSerialized] Zb05_Control parent;
    public Zb05_DeadState(Zb05_Control control) : base("Dead", control)
    {
        this.parent = control;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Dead = true;
    }
}
