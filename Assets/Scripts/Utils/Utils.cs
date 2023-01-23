using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// Creates a new Vector2 using an angle and a magnitude
    /// </summary>
    /// <param name="angle">The angle of the Vector2 in degrees</param>
    /// <param name="magnitude">The magnitude of the Vector2</param>
    /// <returns></returns>
    public static Vector2 Vec2FromComps(float angle, float magnitude)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * magnitude;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * magnitude;

        return new Vector2(x, y);
    }

    /// <summary>
    /// Creates a new Vector3 using the provided angles and magnitude
    /// </summary>
    /// <param name="pitch">The pitch of the vector in degrees</param>
    /// <param name="yaw">The yaw of the vector in degrees</param>
    /// <param name="magnitude">The magnitude of the vector</param>
    /// <returns></returns>
    public static Vector3 Vec3FromComps(float pitch, float yaw, float magnitude)
    {
        pitch *= Mathf.Deg2Rad;
        yaw *= Mathf.Deg2Rad;

        float x = magnitude * Mathf.Cos(pitch) * Mathf.Cos(yaw);
        float y = magnitude * Mathf.Sin(pitch);
        float z = magnitude * Mathf.Cos(pitch) * Mathf.Sin(yaw);

        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Takes a Vector and adds the given angle, returning a resulting vector with the
    /// same magnitude but a diferent m_direction
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

    /// <summary>
    /// Returns whether two numbers are within a certain margin of each other
    /// </summary>
    public static bool ApproxEq(float left, float right, float margin)
    {
        return left <= right + margin && left >= right - margin;
    }
}
