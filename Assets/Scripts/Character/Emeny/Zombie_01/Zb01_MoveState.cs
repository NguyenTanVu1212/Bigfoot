using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb01_MoveState : FSMState
{

    [NonSerialized] public ZbControl_01 parent;
    public Zb01_MoveState(FSMSystem system) : base("Move", system)
    {
        this.parent = (ZbControl_01)system;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Speed = parent.Speed;
    }
    public override void OnUpdate()
    { 
        base.OnUpdate();
        parent.dataBinding.Speed = parent.Speed;
        parent.gameObject.transform.Translate(parent.dir * Time.deltaTime * parent.Speed * 0.1f);
    }
}
