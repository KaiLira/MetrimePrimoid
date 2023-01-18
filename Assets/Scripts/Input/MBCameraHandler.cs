using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles Camera movement for the morph ball, including following the
/// player around, changing the angle according to input as well as
/// moving to avoid obstructions.
/// </summary>
public class MBCameraHandler : MonoBehaviour
{
    public Transform m_morphBall;
    public float m_targetPitch;
    public float m_targetYaw;
    public float m_targetDistance;
    public float m_speed;
    public float m_sensitivity = 50;
    private Vector2 m_intention = Vector2.zero;

    void FixedUpdate()
    {
        // Modify angles with input
        m_targetYaw -= m_intention.x * m_sensitivity * Time.fixedDeltaTime;
        m_targetYaw = Mathf.Abs(m_targetYaw) % 360f;
        m_targetPitch = Mathf.Clamp(
            m_targetPitch + m_intention.y * m_sensitivity * Time.fixedDeltaTime,
            5,
            80
            );
        m_targetPitch = Mathf.Abs(m_targetPitch) % 360f;

        // Get the target position of the camera
        Vector3 targetPos = Utils.Vec3FromComps
            (m_targetPitch, m_targetYaw, m_targetDistance)
            + m_morphBall.position;

        // Lerp the position of the camera
        transform.position = Vector3.Lerp
            (transform.position, targetPos, m_speed * Time.fixedDeltaTime);
    }

    public void LookInput(InputAction.CallbackContext context)
    {
        m_intention = context.ReadValue<Vector2>();
    }
}
