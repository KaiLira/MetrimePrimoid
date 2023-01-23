using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

/// <summary>
/// Handles swapping between the fps and morph ball players
/// </summary>
[RequireComponent(typeof(StateMachine))]
public class SwapHandler : MonoBehaviour
{
    public GameObject fpsState;
    public GameObject mbState;
    private StateMachine sm;
    private Transform fpsPos, mbPos;

    void Start()
    {
        sm = GetComponent<StateMachine>();
        fpsPos = fpsState.GetComponentInChildren<Rigidbody>().transform;
        mbPos = mbState.GetComponentInChildren<Rigidbody>().transform;
    }

    public void SwapInput(InputAction.CallbackContext context)
    {
        if (!(context.interaction is PressInteraction))
            return;

        if (sm._states.Peek() == mbState)
        {
            fpsPos.position = mbPos.position;
            sm.SetState(fpsState);
        }
        else
        {
            mbPos.position = fpsPos.position + Vector3.up;
            sm.SetState(mbState);
        }
    }
}
