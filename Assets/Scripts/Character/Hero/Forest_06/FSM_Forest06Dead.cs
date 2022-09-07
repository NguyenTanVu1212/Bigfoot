using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest06Dead : FSMState
{
    [NonSerialized] public Forest06_Control parent;
    public FSM_Forest06Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest06_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
