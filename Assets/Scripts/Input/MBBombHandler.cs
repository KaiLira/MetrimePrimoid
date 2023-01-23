using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles firing input, ammo count and object instancing for the
/// bombs of the morph ball
/// </summary>
public class MBBombHandler : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform morphBall;
    private const int maxAmmo = 3;
    private int currentAmmo = maxAmmo;
    private float timeSinceFire = 0f;
    private const float reloadTime = 2f;
    private bool doubleInputCorrector = true;

    public void FireInput(InputAction.CallbackContext context)
    {
        doubleInputCorrector = !doubleInputCorrector;
        if (!context.ReadValueAsButton() || doubleInputCorrector || !gameObject.activeInHierarchy)
            return;

        if (currentAmmo > 0)
        {
            var bomb = Instantiate(bombPrefab);
            bomb.transform.position = morphBall.position;
            currentAmmo -= 1;
            timeSinceFire = 0;
        }
    }

    void Update()
    {
        timeSinceFire += Time.deltaTime;
        if (timeSinceFire >= reloadTime && currentAmmo < maxAmmo)
            currentAmmo = maxAmmo;

    }
}
