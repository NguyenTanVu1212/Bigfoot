using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest08Idle : FSMState
{
    [NonSerialized] public Forest08_Control parent;
    public FSM_Forest08Idle(FSMSystem system) : base("Idle", system)
    {
        parent = (Forest08_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
