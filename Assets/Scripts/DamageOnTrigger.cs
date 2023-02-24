using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DamageOnTrigger : MonoBehaviour
{
    public int damage;
    public UnityEvent m_collided;

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage(
            "ChangeHealth",
            -damage,
            SendMessageOptions.DontRequireReceiver
            );

        m_collided?.Invoke();
    }
}
