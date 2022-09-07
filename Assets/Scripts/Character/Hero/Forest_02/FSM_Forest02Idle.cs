using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest02Idle : FSMState
{
    [NonSerialized] public Forest02_Control parent;
    public FSM_Forest02Idle(FSMSystem system) : base("Idle", system)
    {
        parent = (Forest02_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
