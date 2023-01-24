using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Unity.VisualScripting;

public class ScrStateMachine : MonoBehaviour
{
    public State m_Patrol;
    //private State m_FollowTarget;
    public State m_AttackTarget;

    public State m_Current;

    public void SetState(State NewCurrent)
    {
        m_Current.OnExit();
        m_Current = NewCurrent;
        m_Current.OnEnter();
    }

    void Start()
    {
        m_Patrol = gameObject.AddComponent<Patrol>();
        m_Patrol.SetFSM(this);

        m_AttackTarget = gameObject.AddComponent<Attack>();
        m_AttackTarget.SetFSM(this);

        m_Current = m_Patrol;
        m_Current.OnEnter();
    }
    private void Update()
    {
        m_Current.OnUpdate();
    }
}
