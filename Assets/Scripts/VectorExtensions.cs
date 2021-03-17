using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 ToVector2(this Vector3 vec) =>
        new Vector2(vec.x, vec.y);

    public static Vector2 Clamp(this Vector2 vec, Vector2 min, Vector2 max)
    {
        var xPos = Mathf.Clamp(vec.x, min.x, max.x);
        var yPos = Mathf.Clamp(vec.y, min.y, max.y);
        return new Vector2(xPos, yPos);
    }

    public static bool InsideZone(this Vector3 pos, Vector2 min, Vector2 max) => 
        pos.x > min.x && pos.x < max.x && pos.y > min.y && pos.y < max.y;
}