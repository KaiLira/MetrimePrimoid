using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Recieves input events from a PlayerInput, and modifies the
/// forces in the player's rigid body to acquire the desired
/// movement.
/// </summary>
public class MovementHandler : MonoBehaviour
{
    public AudioSource m_Audio;

    public CharacterController m_player;
    public float m_speed;
    public float m_gravity;
    public float m_jumpForce;
    private Vector2 m_intention = Vector2.zero;
    private float prevYSpd = 0;
    private Vector2 flatVel = Vector2.zero;

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
        m_intention = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Listener for the PlayerInput's "Jump" event, when pressed it adds a m_speed upward
    /// to the player, if released mid-jump, it zeroes the vertical m_speed of the player.
    /// </summary>
    /// <param name="context">Automatically passed context in the PlayerInput event</param>
    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed &&
            m_player.isGrounded)
        {
            prevYSpd = m_jumpForce;
        }
    }

    private void Update()
    {
        if (m_intention == Vector2.zero)
        {
            if (m_player.isGrounded)
                flatVel = Vector2.zero;
            else
                flatVel *= 0.99f;
        }
        else
            flatVel = Utils.RotateVec2
                (m_intention, m_player.transform.rotation.eulerAngles.y) * m_speed;

        if (!m_player.isGrounded)
        {
            prevYSpd -= m_gravity * Time.deltaTime;
        }

        var motion = new Vector3(flatVel.x, prevYSpd, flatVel.y) * Time.deltaTime;
        m_player.Move(motion);
        m_Audio.Play();
        if  (m_player.velocity.magnitude <= 0)
        {
            m_Audio.Pause();
        }
    }
}
