using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest08Attack : FSMState
{
    [NonSerialized] public Forest08_Control parent;
    public FSM_Forest08Attack(FSMSystem system) : base("Attack", system)
    {
        parent = (Forest08_Control)system;
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
