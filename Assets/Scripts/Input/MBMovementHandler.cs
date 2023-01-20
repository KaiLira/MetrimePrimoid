using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles movement input by adding forces to the rigid body according
/// to what the player would expect to happen when moving
/// </summary>
public class MBMovementHandler : MonoBehaviour
{
    public Rigidbody m_morphBall;
    public Transform m_camera;
    public float m_force;
    public float m_maxSpeed;
    private Vector2 m_intention = Vector2.zero;
    [HideInInspector]
    public bool m_clampingVel = true;

    public void MoveInput(InputAction.CallbackContext context)
    {
        m_intention = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        var flatForce = Utils.RotateVec2
            (m_intention, m_camera.rotation.eulerAngles.y)
            * m_force;

        m_morphBall.AddForce(flatForce.x, 0, flatForce.y);

        if (m_clampingVel)
            m_morphBall.velocity = Vector3.ClampMagnitude
                (m_morphBall.velocity, m_maxSpeed);
        else
            m_clampingVel = m_morphBall.velocity.magnitude < m_maxSpeed * 0.9f;
    }
}
