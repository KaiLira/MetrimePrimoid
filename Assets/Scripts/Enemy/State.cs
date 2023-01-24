using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public StateMachine m_StateMachine;
    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
    
    public virtual void SetFSM(StateMachine FSM)
    {
        m_StateMachine = FSM;
    }
}
