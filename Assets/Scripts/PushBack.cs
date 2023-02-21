using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[
    RequireComponent(typeof(Collider)),
    RequireComponent(typeof(PowerSetter))
]
public class PushBack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rb))
        {
            Vector3 force = transform.forward * GetComponent<PowerSetter>().m_pushPower;
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
