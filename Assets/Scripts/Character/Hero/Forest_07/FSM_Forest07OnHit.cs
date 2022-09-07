using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest07OnHit : FSMState
{
    [NonSerialized] public Forest07_Control parent;
    public FSM_Forest07OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest07_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
