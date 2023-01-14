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
    public Transform m_player;
    public float m_speed = 5;
    private Vector2 m_intention = Vector2.zero;

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
        m_intention = context.ReadValue<Vector2>() * m_speed;
    }

    void Update()
    {
        m_player.Translate(
            m_intention.x * Time.deltaTime,
            0,
            m_intention.y * Time.deltaTime
            );
    }
}
