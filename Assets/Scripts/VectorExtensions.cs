using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 ToVector2(this Vector3 vec) =>
        new Vector2(vec.x, vec.y);
}