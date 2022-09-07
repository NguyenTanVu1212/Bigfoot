using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest05OnHit : FSMState
{

    [NonSerialized] public Forest05_Control parent;
    public FSM_Forest05OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest05_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
}
