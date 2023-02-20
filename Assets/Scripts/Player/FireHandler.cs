using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FireHandler : MonoBehaviour
{
    [Range(0f, 1f)]
    public float m_minCharge;
    [Range(0f, 1f)]
    public float m_maxCharge;
    public AnimationCurve m_growthCurve;
    public Transform m_muzzle;
    public GameObject m_bulletPrefab;
    public GameObject m_pushPrefab;

    private bool m_pressing = false;
    private float m_charge = 0f;

    public void FireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (context.ReadValueAsButton())
                m_pressing = true;
            else
            {
                if (m_charge < m_minCharge)
                    Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);

                else
                {
                    var push = Instantiate
                        (m_pushPrefab, m_muzzle);
                    push.GetComponent<PowerSetter>().SetPower(
                        m_growthCurve.Evaluate
                        (Mathf.Clamp01((m_charge - m_minCharge) / m_maxCharge))
                        );
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
