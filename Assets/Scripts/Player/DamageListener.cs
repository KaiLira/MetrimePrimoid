using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageListener : MonoBehaviour
{
    public Health health;

    public void ChangeHealth(int delta)
    {
        health.ChangeHealth(delta);
    }
}
