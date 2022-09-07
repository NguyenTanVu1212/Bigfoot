using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    public List<FSMState> lsState = new List<FSMState>();
    public FSMState currentState;
    public FSMState reverState;
    #region State
    public void AddState(FSMState state)
    {
        lsState.Add(state);
        if(lsState.Count==1)
        {
            currentState = state;
            currentState.OnEnter();
        }
    }
    public void GotoState(FSMState state)
    {
        if (currentState != null)
        {
            reverState = currentState;
            currentState.OnExit();
        }
            
        if (!lsState.Contains(state))
        {
            AddState(state);
            return;
        }
        currentState = state;
        currentState.OnEnter();
    }
    #endregion

    #region Unity Behaviour
    private void Start()
    {
        OnSystemStart();
    }
    private void Update()
    {
        
        OnSystemUpdate();
    }
    private void FixedUpdate()
    {
        OnSystemFixUpdate();
    }
    private void LateUpdate()
    {
        OnSystemLateUpdate();
    }

    public virtual void OnSystemUpdate()
    {
        currentState.OnUpdate();
    } 
    public virtual void OnSystemLateUpdate()
    {
        currentState.OnLateUpdate();
    }
    public virtual void OnSystemStart()
    {
        currentState.OnEnter();
    }
    public virtual void OnSystemFixUpdate()
    {
        currentState.OnFixUpdate();
    }
    #endregion
}
