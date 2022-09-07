using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_ForestOnHit : FSMState
{
    [NonSerialized] public Forest01_Control parent;
    public FSM_ForestOnHit(FSMSystem system) : base("OnHit" , system)
    {
        parent =(Forest01_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
    }
}
