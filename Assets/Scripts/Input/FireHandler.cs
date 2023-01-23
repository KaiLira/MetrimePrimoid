using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireHandler : MonoBehaviour
{
    public Transform m_muzzle;
    public GameObject m_bulletPrefab;

    public void FireInput(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton() || !gameObject.activeInHierarchy)
            return;

        var bullet = Instantiate(m_bulletPrefab);
        bullet.transform.SetPositionAndRotation(m_muzzle.position, m_muzzle.rotation);
    }
}
