using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetForceOnTrigger : MonoBehaviour
{
    public Vector3 m_direction = Vector3.up;
    public float m_speed;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rb))
            rb.velocity = m_direction * m_speed;
    }
}
