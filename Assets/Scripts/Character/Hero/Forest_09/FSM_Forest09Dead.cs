using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest09Dead : FSMState
{
    [NonSerialized] public Forest09_Control parent;
    public FSM_Forest09Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest09_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}

