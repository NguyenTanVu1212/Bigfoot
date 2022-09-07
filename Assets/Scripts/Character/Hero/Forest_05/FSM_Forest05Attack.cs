using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest05Attack : FSMState
{
    [NonSerialized] public Forest05_Control parent;
    public FSM_Forest05Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest05_Control)system;
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
