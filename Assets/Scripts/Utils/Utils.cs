using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// Creates a new Vector2 using an angle and a magnitude
    /// </summary>
    /// <param name="angle">The angle of the Vector2 in degrees</param>
    /// <param name="magnitude">The magnitude of the  Vector2</param>
    /// <returns></returns>
    public static Vector2 VecFromComps(float angle, float magnitude)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * magnitude;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * magnitude;

        return new Vector2(x, y);
    }

    /// <summary>
    /// Takes a Vector and adds the given angle, returning a resulting vector with the
    /// same magnitude but a diferent direction
    /// </summary>
    /// <param name="vec">The vector to rotate</param>
    /// <param name="angle">The angle in degrees to be added</param>
    /// <returns></returns>
    public static Vector2 RotateVec2(Vector2 vec, float angle)
    {
        angle *= -1;

        return new Vector2(
            vec.x * Mathf.Cos(angle * Mathf.Deg2Rad) -
            vec.y * Mathf.Sin(angle * Mathf.Deg2Rad),

            vec.x * Mathf.Sin(angle * Mathf.Deg2Rad) +
            vec.y * Mathf.Cos(angle * Mathf.Deg2Rad)
        );
    }
}
