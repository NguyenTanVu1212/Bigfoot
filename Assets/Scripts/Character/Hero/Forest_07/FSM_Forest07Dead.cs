using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest07Dead : FSMState
{
    [NonSerialized] public Forest07_Control parent;
    public FSM_Forest07Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest07_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
