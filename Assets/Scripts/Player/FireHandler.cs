using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FireHandler : MonoBehaviour
{
    [Range(0f, 1f)]
    public float m_minCharge;
    [Range(0f, 1.5f)]
    public float m_maxCharge;
    public AnimationCurve m_growthCurve;
    public Transform m_muzzle;
    public GameObject m_bulletPrefab;
    public GameObject m_pushObj;
    public AudioSource m_Audio;

    private bool m_pressing = false;
    private float m_charge = 0f;

    public void FireInput(InputAction.CallbackContext context)
    {
        if (!isActiveAndEnabled)
            return;

        if (context.phase == InputActionPhase.Performed)
        {
            if (context.ReadValueAsButton())
                m_pressing = true;
            else
            {
                if (m_charge < m_minCharge)
                {
                    Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);
                    m_Audio.Play();
                }  
                else
                {
                    m_pushObj.GetComponent<PowerSetter>().SetPower(
                        m_growthCurve.Evaluate(Mathf.Clamp01(
                            m_charge / (m_maxCharge + m_minCharge)
                            ))
                        );

                    m_pushObj.SetActive(true);
                }

                m_pressing = false;
                m_charge= 0f;
            }
        }
    }

    private void Update()
    {
        if (m_pressing)
            m_charge += Time.deltaTime;
    }
}
