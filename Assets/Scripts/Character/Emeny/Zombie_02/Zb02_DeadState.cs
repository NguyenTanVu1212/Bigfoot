using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb02_DeadState : FSMState
{
    [NonSerialized] public EnemyBehaviour parent;
    public Zb02_DeadState(FSMSystem control) : base("dead", control)
    {
        this.parent = (EnemyBehaviour)control;
    }
    public override void OnEnter()
    {
        parent.dataBinding.Dead = true;      
    }
}
