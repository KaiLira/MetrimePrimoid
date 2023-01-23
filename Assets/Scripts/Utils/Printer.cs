using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This exposes a method to print whatever you want to console
/// to be used as a UnityEvent listener for debugging purposes
/// </summary>
public class Printer : MonoBehaviour
{
    public void Print(string text)
    {
        Debug.Log(text);
    }
}
