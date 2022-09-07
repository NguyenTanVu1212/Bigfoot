using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest04Idle : FSMState
{
    [NonSerialized] public Forest04_Control parent;
    public FSM_Forest04Idle(FSMSystem system) : base("Idle", system)
    {
        parent = (Forest04_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
