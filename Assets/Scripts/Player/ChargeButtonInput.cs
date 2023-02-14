using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Calls unity events with a float between 0 and 1 indicating it's progress
/// to a "fully charged" input
/// </summary>
public class ChargeButtonInput : MonoBehaviour
{
    public float m_maxTime;
    private float m_currentTime = 0;
    private bool m_isPressed;
    public UnityEvent<float> m_buttonInput;

    public float ChargeRate
    {
        get
        {
            return Mathf.Clamp01(m_currentTime / m_maxTime);
        }
    }

    public void ButtonInput(InputAction.CallbackContext context)
    {
        m_isPressed = context.ReadValueAsButton();
        if (!m_isPressed)
        {
            m_buttonInput?.Invoke(ChargeRate);
            m_currentTime = 0;
        }
    }

    void Update()
    {
        if (m_isPressed)
            m_currentTime += Time.deltaTime;
    }
}
