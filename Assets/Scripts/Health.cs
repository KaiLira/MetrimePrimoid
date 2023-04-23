using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int m_maxHealth;
    private int m_health;
    public AudioSource m_audioSource;
    // Is sent out when damage is taken,the integer
    // contains the new current HP
    public UnityEvent<int> m_damaged;
    // Is sent out when the entity is healed,the integer
    // contains the new current HP
    public UnityEvent<int> m_healed;
    public UnityEvent m_depleted;

    private void Start()
    {
        m_health = m_maxHealth;
    }

    /// <summary>
    /// Adds the specified amount to the health of the object
    /// and sends out the relevant UnityEvents, to deal damage,
    /// simply pass a negative number.
    /// </summary>
    /// <param name="delta">The amount to change the health by</param>
    public void ChangeHealth(int delta)
    {
        m_health = Math.Clamp(m_health + delta, 0, m_maxHealth);

        if (m_health > 0)
            m_damaged?.Invoke(m_health);
        else
            m_audioSource.Play();
            m_depleted?.Invoke();
    }
}
