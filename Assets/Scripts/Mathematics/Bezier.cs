using UnityEngine;

namespace com.GE1Assignment.Mathematics {

    public static class Bezier {

        public static Vector3 Vector3QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t) {
            Vector3 p0 = Vector3.Lerp(a, b, t);
            Vector3 p1 = Vector3.Lerp(b,c, t);
            return Vector3.Lerp(p0, p1, t);
        }

        public static Vector3 Vector3CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) {
            Vector3 p0 = Vector3QuadraticCurve(a, b, c, t);
            Vector3 p1 = Vector3QuadraticCurve(b, c, d, t);
            return Vector3.Lerp(p0, p1, t);
        }
        
        public static Vector2 Vector2QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t) {
            Vector2 p0 = Vector2.Lerp(a, b, t);
            Vector2 p1 = Vector2.Lerp(b,c, t);
            return Vector2.Lerp(p0, p1, t);
        }
        
        public static Vector2 Vector2CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t) {
            Vector2 p0 = Vector2QuadraticCurve(a, b, c, t);
            Vector2 p1 = Vector2QuadraticCurve(b, c, d, t);
            return Vector2.Lerp(p0, p1, t);
        }
    
    }

}
