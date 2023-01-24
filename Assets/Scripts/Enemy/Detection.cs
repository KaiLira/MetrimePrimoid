using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool m_IsEnemy =  false;
    public Vector3 m_Direction;

    private void OnTriggerEnter(Collider other)
    {
        m_IsEnemy = other.gameObject.CompareTag("Player");
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (m_IsEnemy)
        {
            m_Direction = other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_IsEnemy = false;
        m_Direction = Vector3.zero;
    }
}
