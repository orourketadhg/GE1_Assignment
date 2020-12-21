using System;
using UnityEngine;
using Random = System.Random;


namespace com.GE1Assignment.Path {

    public class PathBuilder : MonoBehaviour {
        public float spacing = 0.1f;
        public float resolution = 1;

        private void Start() {
            Vector2[] points = FindObjectOfType<PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);

            foreach (var point in points) {
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                g.transform.position = point;
                g.transform.localScale = new Vector3(0.3f, 0.2f, 0.1f);
                g.transform.parent = transform;
                g.layer = 8;
                
                g.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
                g.AddComponent<MeshCollider>();
                Destroy(GetComponent<SphereCollider>());
            }
            
            transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            transform.localScale = new Vector3(100, 100, 100);

        }
    }

}