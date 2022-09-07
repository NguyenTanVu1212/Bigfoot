using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest04Dead : FSMState
{
    [NonSerialized] public Forest04_Control parent;
    public FSM_Forest04Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest04_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
