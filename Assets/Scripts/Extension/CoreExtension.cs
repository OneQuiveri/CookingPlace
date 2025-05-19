using UnityEngine;

public static class CoreExtension
{
    public static Vector2 ToVector2(this Vector3 vector) 
    {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector2 AddFloat(this Vector3 vector, float value) 
    {
        return new Vector2(vector.x + value, vector.y + value);
    }
}
