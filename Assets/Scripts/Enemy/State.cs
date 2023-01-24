using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public ScrStateMachine m_StateMachine;
    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
    
    public virtual void SetFSM(ScrStateMachine FSM)
    {
        m_StateMachine = FSM;
    }
}
