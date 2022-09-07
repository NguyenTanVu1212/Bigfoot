using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest08OnHit : FSMState
{
    [NonSerialized] public Forest08_Control parent;
    public FSM_Forest08OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest08_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    
}
