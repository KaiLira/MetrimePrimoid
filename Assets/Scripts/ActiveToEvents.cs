using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveToEvents : MonoBehaviour
{
    public UnityEvent m_onEnable;
    public UnityEvent m_onDisable;

    private void OnEnable()
    {
        m_onEnable?.Invoke();
    }

    private void OnDisable()
    {
        m_onDisable?.Invoke();
    }
}
