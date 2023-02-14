using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/// <summary>
/// Handles pausing and unpausing, as well as different pause screens
/// like death and a pause menu.
/// </summary>
[CreateAssetMenu(
    fileName = "GameManager",
    menuName = "ScriptableObjects/Create GameManager"
)]
public class GameManager : ScriptableObject
{
    public GameObject pauseMenu;
    public GameObject blackScreen;
    public GameObject gameOver;

    /// <summary>
    /// When the player dies, this function should be called
    /// 
    /// it pauses the game and instantiates the death screen game over object
    /// </summary>
    public void OnDeath()
    {
        Time.timeScale = 0f;
        Instantiate(gameOver);
    }

    /// <summary>
    /// Restarts whatever the current scene is
    /// </summary>
    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Loads the specified scene
    /// </summary>
    /// <param name="name">The scene to be loaded</param>
    public void LoadScene(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Pauses the game and instantiates the pause menu
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Instantiate(pauseMenu);
    }

    /// <summary>
    /// Resumes the game and ensures the pause menu is destroyed
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindWithTag("PauseMenu"));
    }

    /// <summary>
    /// This is a listener for a UnityEvent that PlayerInput invokes.
    /// 
    /// It pauses and unpauses the game depending on input and state.
    /// </summary>
    /// <param name="context">Automatically passed value by PlayerInput</param>
    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!GameObject.FindWithTag("PauseMenu"))
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    /// <summary>
    /// This is a listener for a UnityEvent that PlayerInput invokes.
    /// 
    /// It reloads the scene when the input recquires so.
    /// </summary>
    /// <param name="context">Automatically passed value by PlayerInput</param>
    public void OnSelectButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ReloadScene();
        }
    }
}