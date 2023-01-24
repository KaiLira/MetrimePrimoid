using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes a unity event after a set delay
/// </summary>
public class EventAfterDelay : MonoBehaviour
{
    public float m_delay;
    public UnityEvent m_event;

    void Start()
    {
        StartCoroutine(invokeAfter());
    }

    private IEnumerator invokeAfter()
    {
        yield return new WaitForSeconds(m_delay);
        m_event?.Invoke();
    }
}
