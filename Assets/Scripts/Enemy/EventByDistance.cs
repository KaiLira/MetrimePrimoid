using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventByDistance : MonoBehaviour
{
    public TargetHolder targetHolder;
    public float range;
    public UnityEvent rangeEntered;
    public UnityEvent rangeExited;
    private float prevDistance = -1f;

    private void Start()
    {
        prevDistance = (transform.position - targetHolder.Target.transform.position).magnitude;
    }

    private void Update()
    {
        float distance = (transform.position - targetHolder.Target.transform.position).magnitude;
        
        if (prevDistance >= range && distance < range)
            rangeEntered?.Invoke();

        if (prevDistance <= range && distance > range)
            rangeExited?.Invoke();

        prevDistance = distance;
    }
}
