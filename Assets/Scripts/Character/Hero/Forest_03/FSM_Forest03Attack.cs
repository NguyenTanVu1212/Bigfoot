using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest03Attack : FSMState
{
    [NonSerialized] public Forest03_Control parent;
    public FSM_Forest03Attack(FSMSystem system) : base("OnHit", system)
    {
        parent = (Forest03_Control)system;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (parent.timeCount < 0)
        {
            parent.dataBinding.Attack = true;
            parent.OnAttack();
        }
    }
}
