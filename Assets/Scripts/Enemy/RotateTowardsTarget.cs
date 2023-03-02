using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    public TargetHolder m_holder;
    public Transform m_self;

    private void Update()
    {
        var angle = - Vector3.SignedAngle(
            m_holder.Target.transform.position - m_self.position,
            Vector3.forward, Vector3.up
            );

        m_self.rotation = Quaternion.Euler(0, angle, 0);
    }
}
