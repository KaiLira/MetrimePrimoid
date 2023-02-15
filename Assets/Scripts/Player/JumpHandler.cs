using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles jump inputs
/// </summary>
public class JumpHandler : MonoBehaviour
{
    public CharacterController m_player;
    public float m_jumpForce = 10f;

    /// <summary>
    /// Listener for the PlayerInput's "Jump" event, when pressed it adds a m_speed upward
    /// to the player, if released mid-jump, it zeroes the vertical m_speed of the player.
    /// </summary>
    /// <param name="context">Automatically passed context in the PlayerInput event</param>
    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && m_player.isGrounded)
        {
        }
    }
}
