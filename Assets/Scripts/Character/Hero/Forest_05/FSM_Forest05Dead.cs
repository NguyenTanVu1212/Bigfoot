using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]

public class FSM_Forest05Dead : FSMState
{
    [NonSerialized] public Forest05_Control parent;
    public FSM_Forest05Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest05_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
