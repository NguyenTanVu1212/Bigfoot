using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]


public class Zb02_IdleState : FSMState
{
    [NonSerialized] public EnemyBehaviour parent;
    public Zb02_IdleState(FSMSystem control) : base("idle", control)
    {
        this.parent = (EnemyBehaviour)control;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Speed = 0f;
    }
}
