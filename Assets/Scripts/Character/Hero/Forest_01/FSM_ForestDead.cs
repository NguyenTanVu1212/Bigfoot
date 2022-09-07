using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_ForestDead : FSMState
{
    [NonSerialized] public Forest01_Control parent;
    public FSM_ForestDead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest01_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
