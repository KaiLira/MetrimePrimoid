using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the object it's attatched to forward at the set m_speed
/// </summary>
public class TranslateForward : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
