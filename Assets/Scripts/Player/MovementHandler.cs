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
    public CharacterController m_player;
    public float m_speed = 5;
    public float m_gravity = 10;
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
        m_intention = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        var prevY = m_player.velocity.y - m_gravity;
        var flatVel = Utils.RotateVec2
            (m_intention, m_player.transform.rotation.eulerAngles.y) * m_speed;

        var motion = new Vector3(flatVel.x, prevY, flatVel.y) * Time.deltaTime;

        m_player.Move(motion);
    }
}
