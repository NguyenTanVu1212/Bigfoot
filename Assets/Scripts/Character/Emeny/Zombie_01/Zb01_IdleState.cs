using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb01_IdleState : FSMState
{
    [NonSerialized] public ZbControl_01 parent;
    public Zb01_IdleState(FSMSystem system) : base("Idle" ,system )
    {
        this.parent = (ZbControl_01)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Speed = 0f;
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
