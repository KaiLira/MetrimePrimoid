using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lerps the rotation of the object it's attatched to so it's local
/// positive Z it's facing towards the target.
/// </summary>
public class RotateTowardTarget : MonoBehaviour
{
    public Transform m_target;
    public float m_turnRate;

    void Update()
    {
        var lookingRot = Quaternion.LookRotation
            (m_target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp
            (lookingRot, transform.rotation, m_turnRate * Time.deltaTime);
    }
}
