using UnityEngine;

namespace com.GE1Assignment.Mathematics {

    public static class Bezier {

        public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t) {
            Vector3 p0 = Vector3.Lerp(a, b, t);
            Vector3 p1 = Vector3.Lerp(b,c, t);
            return Vector3.Lerp(p0, p1, t);
        }

        public static Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) {
            Vector3 p0 = QuadraticCurve(a, b, c, t);
            Vector3 p1 = QuadraticCurve(b, c, d, t);
            return Vector3.Lerp(p0, p1, t);
        }
    
    }

}
