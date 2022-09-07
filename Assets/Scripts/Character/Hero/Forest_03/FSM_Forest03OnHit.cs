using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest03OnHit : FSMState
{
    [NonSerialized] public Forest03_Control parent;
    public FSM_Forest03OnHit(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest03_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        //parent.dataBinding.Onhit = true;
    }
}
