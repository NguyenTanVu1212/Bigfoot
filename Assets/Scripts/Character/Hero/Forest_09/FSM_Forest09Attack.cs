using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest09Attack : FSMState
{
    [NonSerialized] public Forest09_Control parent;
    public FSM_Forest09Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest09_Control)system;
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
