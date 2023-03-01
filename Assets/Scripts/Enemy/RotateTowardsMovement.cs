using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMovement : MonoBehaviour
{
    public Rigidbody body;

    private void Update()
    {
        float yaw = Vector3.SignedAngle
            (Vector3.forward, body.velocity, Vector3.up);

        body.transform.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
