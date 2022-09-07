using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState
{
    protected FSMSystem system;
    public string nameState;
    public FSMState(string _name , FSMSystem _system)
    {
        nameState = _name;
        system = _system;
    }
    public virtual void OnSetup()
    {

    }
    public virtual void OnEnter()
    {

    }
    public virtual void OnUpdate()
    {

    }
    public virtual void OnFixUpdate()
    {

    }
    public virtual void OnLateUpdate()
    {

    }
    public virtual void OnExit()
    {

    }
}
