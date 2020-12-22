using System;
using UnityEngine;

namespace com.GE1Assignment.Kinematics {

    public class RaycastGround : MonoBehaviour {


        public Transform raycastOrigin;

        private void FixedUpdate() {

            // raycast transform to ground
            if (Physics.Raycast(raycastOrigin.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, 1 << 8)) {
                transform.position = hit.point;
            }
        }
        
    }

}