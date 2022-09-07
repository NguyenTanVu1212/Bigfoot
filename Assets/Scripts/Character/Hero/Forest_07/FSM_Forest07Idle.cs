using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest07Idle : FSMState
{
    [NonSerialized] public Forest07_Control parent;
    public FSM_Forest07Idle(FSMSystem system) : base("Idle", system)
    {
        parent = (Forest07_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
