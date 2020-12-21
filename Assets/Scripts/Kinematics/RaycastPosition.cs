using System;
using UnityEngine;

namespace com.GE1Assignment.Kinematics {

    public class RaycastPosition : MonoBehaviour {

        public float height;
        private RaycastHit _hit;

        private void FixedUpdate() {
            Vector3 raycastOrigin = transform.position;
            
            if (Physics.Raycast(raycastOrigin, Vector3.down, out _hit)) {
                transform.position = _hit.point;
            }
        }
        
    }

}