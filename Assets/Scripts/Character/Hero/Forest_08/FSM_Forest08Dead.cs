using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class FSM_Forest08Dead : FSMState
{

    [NonSerialized] public Forest08_Control parent;
    public FSM_Forest08Dead(FSMSystem system) : base("Dead", system)
    {
        parent = (Forest08_Control)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.OnDead();
        parent.dataBinding.Dead = true;
    }
}
