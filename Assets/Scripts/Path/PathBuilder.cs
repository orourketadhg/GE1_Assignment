using System;
using UnityEngine;
using Random = System.Random;


namespace com.GE1Assignment.Path {

    public class PathBuilder : MonoBehaviour {
        public float spacing = 0.1f;
        public float resolution = 1;

        [HideInInspector] public Vector2[] points;

        public int NumPoints => points.Length;

        private void Awake() {
            points = FindObjectOfType<PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);

            // Spawn spheres as path at evenly spaced points
            for (int index = 0; index < points.Length; index++) {
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                points[index] *= 100;
                g.transform.position = new Vector3(points[index].x, 0, points[index].y);
                g.transform.localScale = new Vector3(30, 10, 30);
                g.transform.parent = transform;
                g.layer = 8;

                g.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
                g.AddComponent<MeshCollider>();
                Destroy(g.GetComponent<SphereCollider>());
            }
            
        }
    }

}