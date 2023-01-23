using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class StateMachine : MonoBehaviour
{
    public PathCreator m_PathCreator;
    public EndOfPathInstruction end;
    public float Speed;
    float dstTravelled;

    //private State m_Patrol;
    //private State m_FollowTarget;
    //private State m_AttackTarget;

    private void Update()
    {
        dstTravelled += Speed + Time.deltaTime;
        transform.position = m_PathCreator.path.GetPointAtDistance(dstTravelled, end);
        transform.rotation = m_PathCreator.path.GetRotationAtDistance(dstTravelled, end);
    }

}
