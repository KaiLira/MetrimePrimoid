using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Recieves input events from a PlayerInput, and modifies the
/// forces in the player's rigid body to acquire the desired
/// movement.
/// </summary>
public class MovementHandler : MonoBehaviour
{
    public Rigidbody m_playerBody;
    public float m_speed = 5;

    /// <summary>
    /// This is the listener to be added to the corresponding movement
    /// event in the PlayerInput
    /// </summary>
    /// 
    /// <param name="context">
    /// This recieves the context the PlayerInput automatically passes
    /// </param>
    public void MovementInput(InputAction.CallbackContext context)
    {
        Vector2 intention = context.ReadValue<Vector2>();
        if (intention == Vector2.zero)
            m_playerBody.velocity = Vector2.zero;

        intention *= m_speed;

        float angle = m_playerBody.transform.rotation.eulerAngles.y;
        intention = Utils.RotateVec2(intention, angle);

        m_playerBody.velocity = new Vector3(intention.x, 0, intention.y);
    }
}
