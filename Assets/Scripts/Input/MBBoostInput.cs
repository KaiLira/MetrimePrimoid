using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBBoostInput : MonoBehaviour
{
    public MBMovementHandler m_mvHndlr;
    public Rigidbody m_morphBall;
    public float m_speed;

    public void ChargeButtonInput(float amount)
    {

        if (amount < 0.95f)
            return;

        m_morphBall.velocity = m_morphBall.velocity.normalized * m_speed;
        m_mvHndlr.m_clampingVel = false;
    }
}
