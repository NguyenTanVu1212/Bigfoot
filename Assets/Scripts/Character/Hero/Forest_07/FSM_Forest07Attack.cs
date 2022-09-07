using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest07Attack : FSMState
{
    [NonSerialized] public Forest07_Control parent;
    public FSM_Forest07Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest07_Control)system;
    }
    public override void OnEnter()
    {
        if (parent.timeCount < 0)
        {
            parent.dataBinding.Attack = true;
            parent.OnAttack();
        }
    }
}
