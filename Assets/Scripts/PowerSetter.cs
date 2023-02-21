using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSetter : MonoBehaviour
{
    public float m_basePower;
    [HideInInspector]
    public float m_pushPower;

    public void SetPower(float power)
    {
        m_pushPower = m_basePower * power;
        transform.localScale = Vector3.one * power;
    }
}
