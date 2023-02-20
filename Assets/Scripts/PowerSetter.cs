using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSetter : MonoBehaviour
{
    public float m_pushPower;

    public void SetPower(float power)
    {
        m_pushPower *= power;
        transform.localScale = Vector3.one * power;
    }
}
