using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This handles player and camera rotation to look wherever
/// the player intends to.
/// </summary>
public class LookHandler : MonoBehaviour
{
    public Transform m_player;
    public Transform m_camera;
    public float m_sensitivity = 50f;
    private Vector2 m_intention = Vector2.zero;

    /// <summary>
    /// Each frame, the rotation of the player's and camera's rotation are updated,
    /// The whole player is rotated for horizontal rotation and only the camera
    /// is rotated for vertical rotation, so as to not generate weird stuff with
    /// collisions while looking up or down.
    /// 
    /// Camera rotation is also clamped so you cannot "backflip"
    /// </summary>
    void Update()
    {
        m_player.Rotate(new Vector3(0, m_intention.x * Time.deltaTime, 0));
        m_camera.Rotate(new Vector3(-m_intention.y * Time.deltaTime, 0, 0));

        float pitch = m_camera.rotation.eulerAngles.x;
        if (pitch < -89)
        {
            m_camera.localRotation = Quaternion.Euler(new Vector3(-89, 0, 0));
        }

        if (pitch > 89)
        {
            m_camera.localRotation = Quaternion.Euler(new Vector3(89, 0, 0));
        }
    }

    /// <summary>
    /// Event listener for the Look event of PlayerInput, it changes an internal
    /// "intention" variable that is used each frame to change the player and
    /// camera's rotation
    /// </summary>
    /// <param name="context">Automatically passed context in the PlayerInput event</param>
    public void LookInput(InputAction.CallbackContext context)
    {
        m_intention = context.ReadValue<Vector2>() * m_sensitivity;
    }
}
