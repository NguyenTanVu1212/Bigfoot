using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest04Attack : FSMState
{
    [NonSerialized] public Forest04_Control parent;
    public FSM_Forest04Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest04_Control)system;
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
