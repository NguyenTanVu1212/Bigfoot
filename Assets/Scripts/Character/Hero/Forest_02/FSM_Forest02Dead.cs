using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest02Dead : FSMState
{
    [NonSerialized] public Forest02_Control parent;
    public FSM_Forest02Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest02_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
