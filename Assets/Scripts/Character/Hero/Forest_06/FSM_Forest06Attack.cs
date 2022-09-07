using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]

public class FSM_Forest06Attack : FSMState
{
    [NonSerialized] public Forest06_Control parent;
    public FSM_Forest06Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest06_Control)system;
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
