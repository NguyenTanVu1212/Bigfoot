using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_ForestAttack : FSMState
{
    [NonSerialized] public Forest01_Control parent;
    public FSM_ForestAttack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest01_Control)system;
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
