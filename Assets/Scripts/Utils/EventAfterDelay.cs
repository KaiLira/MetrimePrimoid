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
    public bool autostart = true;
    public bool repeat = false;
    public UnityEvent m_event;

    void OnEnable()
    {
        if (autostart)
            startTimer();
    }

    private void startTimer()
    {
        StartCoroutine(invokeAfter());
    }

    private IEnumerator invokeAfter()
    {
        yield return new WaitForSeconds(m_delay);
        m_event?.Invoke();
        if (repeat)
            startTimer();
    }
}
