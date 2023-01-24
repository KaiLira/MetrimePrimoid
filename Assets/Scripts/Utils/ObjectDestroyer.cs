using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script exists solely to expose the Destroy function to be used
/// with a UnityEvent
/// </summary>
public class ObjectDestroyer : MonoBehaviour
{
    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
