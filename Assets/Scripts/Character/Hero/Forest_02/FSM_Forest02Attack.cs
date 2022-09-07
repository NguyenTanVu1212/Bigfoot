using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest02Attack : FSMState
{
    [NonSerialized] public Forest02_Control parent;
    public FSM_Forest02Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest02_Control)system;
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
