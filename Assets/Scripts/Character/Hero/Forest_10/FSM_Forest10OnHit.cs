using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest10OnHit : FSMState
{
    [NonSerialized] public Forest10_Control parent;
    public FSM_Forest10OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest10_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
