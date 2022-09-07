using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]

public class Zb02_WalkState : FSMState
{
    [NonSerialized] public EnemyBehaviour parent;
    public Zb02_WalkState(FSMSystem control) : base("walk" , control)
    {
        this.parent = (EnemyBehaviour)control;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Speed = parent.data.Speed;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        parent.dataBinding.Speed = parent.Speed;
        parent.gameObject.transform.Translate(parent.dir * Time.deltaTime * parent.Speed * 0.1f);
    }
}
