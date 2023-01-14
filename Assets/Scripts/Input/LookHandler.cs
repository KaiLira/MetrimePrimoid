using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookHandler : MonoBehaviour
{
    public Transform m_player;
    public Transform m_camera;
    public float m_sensitivity = 50f;
    private Vector2 m_intention = Vector2.zero;

    void Update()
    {
        m_player.Rotate(new Vector3(0, m_intention.x * Time.deltaTime, 0));
        m_camera.Rotate(new Vector3(-m_intention.y * Time.deltaTime, 0, 0));
    }

    public void LookInput(InputAction.CallbackContext context)
    {
        m_intention = context.ReadValue<Vector2>() * m_sensitivity;
    }
}
