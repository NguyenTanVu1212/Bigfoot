using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest09Idle : FSMState
{
    [NonSerialized] public Forest09_Control parent;
    public FSM_Forest09Idle(FSMSystem system) : base("Idle", system)
    {
        parent = (Forest09_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
