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
    public float m_sensitivity;
    private Vector2 m_intention = Vector2.zero;

    /// <summary>
    /// Each frame, it rotates the player and camera acording to the intention,
    /// yaw is modified by rotating the whole player so that movement is always
    /// relative towards where you're looking, pitch is handled by rotating the
    /// camera so that the player can't fly by just looking up.
    /// 
    /// Pitch is clamped to avoid the player flipping.
    /// </summary>
    void Update()
    {
        m_player.Rotate(new Vector3(0, m_intention.x * Time.deltaTime, 0));

        float pitch = m_camera.rotation.eulerAngles.x;
        float pitchDelta = -m_intention.y * Time.deltaTime;
        if (pitch < 180 && pitch + pitchDelta > 89)
        {
            m_camera.localRotation = Quaternion.Euler(89, 0, 0);
        }
        else if (pitch > 180 && pitch + pitchDelta < 360 - 89)
        {
            m_camera.localRotation = Quaternion.Euler(-89, 0, 0);
        }
        else
        {
            m_camera.Rotate(pitchDelta, 0, 0);
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
