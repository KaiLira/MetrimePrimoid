using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    protected Detection m_PlayerDetection;
    public PathCreator m_PathCreator;
    public EndOfPathInstruction m_End;
    private float m_Speed;
    [SerializeField] private float m_MaxSpeed;
    public float m_MinSpeed;
    protected float m_Interpolater;
    private float m_dstTravelled;

    public override void OnEnter()
    {
        m_PlayerDetection = transform.Find("Detection").GetComponent<Detection>();
        m_PathCreator = GameObject.Find("PathCreator").GetComponent<PathCreator>();
        m_MaxSpeed = .2f;
        m_MinSpeed = 0.0f;
        m_Interpolater = 0.0f;
        m_Speed = 0;
    }

    public override void OnUpdate()
    {
        if (m_PlayerDetection.m_IsEnemy)
        {
            m_StateMachine.SetState(m_StateMachine.m_AttackTarget);
        }
        if (m_Interpolater < m_MaxSpeed)
        {
            m_Interpolater += 0.2f;
        }
        m_Speed = Mathf.Lerp(m_MinSpeed, m_MaxSpeed, m_Interpolater);
        m_dstTravelled += m_Speed + Time.deltaTime;
        transform.position = m_PathCreator.path.GetPointAtDistance(m_dstTravelled, m_End);
        transform.rotation = m_PathCreator.path.GetRotationAtDistance(m_dstTravelled, m_End);
    }

    public override void OnExit()
    {
        //for( m_Interpolater = 1; m_Interpolater != 0; m_Interpolater--)
        //{
        //    m_dstTravelled += m_Interpolater + Time.deltaTime;
        //    transform.position = m_PathCreator.path.GetPointAtDistance(m_dstTravelled, m_End);
        //    transform.rotation = m_PathCreator.path.GetRotationAtDistance(m_dstTravelled, m_End);
        //}
    }
}
