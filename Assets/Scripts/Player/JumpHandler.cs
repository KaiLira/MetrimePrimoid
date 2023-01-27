using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles jump inputs
/// </summary>
public class JumpHandler : MonoBehaviour
{
    public Rigidbody m_player;
    public float m_strength = 10f;

    /// <summary>
    /// Listener for the PlayerInput's "Jump" event, when pressed it adds a m_speed upward
    /// to the player, if released mid-jump, it zeroes the vertical m_speed of the player.
    /// </summary>
    /// <param name="context">Automatically passed context in the PlayerInput event</param>
    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && Utils.ApproxEq(m_player.velocity.y, 0, 0.2f))
        {
            m_player.AddForce(0, m_strength, 0);
        }

        if (!context.ReadValueAsButton() && m_player.velocity.y > 0)
        {
            m_player.AddForce(0, -m_player.velocity.y * 0.9f, 0, ForceMode.VelocityChange);
        }
    }
}
