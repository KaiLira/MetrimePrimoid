using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FireHandler : MonoBehaviour
{
    public Transform m_muzzle;
    public GameObject m_bulletPrefab;
    private bool doubleInputCorrection = false;

    public void FireInput(InputAction.CallbackContext context)
    {
        doubleInputCorrection = !doubleInputCorrection;

        if (!context.ReadValueAsButton() ||
            !doubleInputCorrection ||
            !gameObject.activeInHierarchy
            )
            return;

        var bullet = Instantiate(m_bulletPrefab);
        bullet.transform.SetPositionAndRotation(m_muzzle.position, m_muzzle.rotation);
    }
}
