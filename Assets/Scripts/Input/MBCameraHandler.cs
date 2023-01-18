using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBCameraHandler : MonoBehaviour
{
    public Transform m_morphBall;
    public float m_targetPitch;
    public float m_targetYaw;
    public float m_targetDistance;
    public float m_speed;

    void FixedUpdate()
    {
        Vector3 targetPos = Utils.Vec3FromComps
            (m_targetPitch, m_targetYaw, m_targetDistance)
            + m_morphBall.position;

        transform.position = Vector3.Lerp
            (transform.position, targetPos, m_speed * Time.fixedDeltaTime);
    }
}
