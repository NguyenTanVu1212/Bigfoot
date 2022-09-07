using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]

public class FSM_Forest10Attack : FSMState
{
    [NonSerialized] public Forest10_Control parent;
    public FSM_Forest10Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest10_Control)system;
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
