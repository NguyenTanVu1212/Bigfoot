using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]
public class Zb05_WalkState : FSMState
{
    [NonSerialized] Zb05_Control parent;
    public Zb05_WalkState(Zb05_Control control) : base("walk", control)
    {
        this.parent = control;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBinding.Speed = parent.data.Speed;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        parent.gameObject.transform.Translate(Vector3.left * Time.deltaTime * 0.1f * parent.Speed);
    }
}
