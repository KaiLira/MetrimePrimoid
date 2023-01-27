using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Pauses and unpauses the game, also handles locking and unlocking of
/// the cursor
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class PauseHandler : MonoBehaviour
{
    private bool doubleInputCorrection = false;
    private PlayerInput playerInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
    }

    public void PauseInput(InputAction.CallbackContext context)
    {
        doubleInputCorrection = !doubleInputCorrection;
        if (doubleInputCorrection || !context.ReadValueAsButton())
            return;

        // If paused, unpause
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
        }
        // If unpaused, pause
        else
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            playerInput.SwitchCurrentActionMap("UI");
        }
    }
}
