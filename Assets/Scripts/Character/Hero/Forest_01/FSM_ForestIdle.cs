using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_ForestIdle : FSMState
{
    [NonSerialized] public Forest01_Control parent;
    public FSM_ForestIdle(FSMSystem system) : base("Idle" , system)
    {
        parent = (Forest01_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();       
    }
}
