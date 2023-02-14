using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FireHandler : MonoBehaviour
{
    public Transform m_muzzle;
    public GameObject m_bulletPrefab;

    public void FireInput(float charge)
    {
        if (charge < 0.95f)
        {
            var bullet = Instantiate(m_bulletPrefab);
            bullet.transform.SetPositionAndRotation(m_muzzle.position, m_muzzle.rotation);
        }
        else
        {

        }
    }
}
