using UnityEngine;

public static class Curves {

    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t) {
        Vector3 p0 = Vector3.Lerp(a, b, t);
        Vector3 p1 = Vector3.Lerp(b,c, t);
        return Vector3.Lerp(p0, p1, t);
    }

    public static Vector2 CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t) {
        Vector2 p0 = QuadraticCurve(a, b, c, t);
        Vector2 p1 = QuadraticCurve(b, c, d, t);
        return Vector2.Lerp(p0, p1, t);
    }
    
}
