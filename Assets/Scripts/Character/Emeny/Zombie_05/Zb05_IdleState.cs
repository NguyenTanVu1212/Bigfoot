using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb05_IdleState : FSMState
{
    [NonSerialized] Zb05_Control parent;
    public Zb05_IdleState(Zb05_Control control) : base("idle", control)
    {
        this.parent = control;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.Speed = parent.Speed;
    }
}
