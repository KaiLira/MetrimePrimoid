using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Delete's the object it's attatched to whenever a collision is registered
/// </summary>
public class DeleteOnContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
