using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest06OnHit : FSMState
{
    [NonSerialized] public Forest06_Control parent;
    public FSM_Forest06OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest06_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
