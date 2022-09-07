using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb01_DeadState : FSMState
{
    [NonSerialized] public ZbControl_01 parent;
    public Zb01_DeadState(FSMSystem system) : base("Dead", system)
    {
        this.parent = (ZbControl_01)system;
    }
    public override void OnEnter()
    {
        parent.dataBinding.Dead = true;
    }
}
