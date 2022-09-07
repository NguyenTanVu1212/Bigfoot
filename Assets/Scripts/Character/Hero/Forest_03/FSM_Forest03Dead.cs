using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest03Dead : FSMState
{
    [NonSerialized] public Forest03_Control parent;
    public FSM_Forest03Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest03_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
