using System;
using UnityEngine;

namespace com.GE1Assignment.Path {

    public class PathCreator : MonoBehaviour {

        [HideInInspector] public Path path;

        public void CreatePath() {
            path = new Path(transform.position);
        }

        private void Reset() {
            CreatePath();
        }

    }

}
