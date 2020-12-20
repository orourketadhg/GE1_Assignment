using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.GE1Assignment.Kinematics {

    public class LegController : MonoBehaviour {

        public Transform target;
        public float movementThreshold = 10;
        public float speed = 1;

        private Vector3 _previousPosition;
        private Vector3 _anchorPoint;
        
        private void Start() {
            CalculateAnchorPoint();
        }

        private void FixedUpdate() {
            Step();
        }

        private void Step() {
            
            if (( target.position - transform.position ).sqrMagnitude >= movementThreshold * movementThreshold) {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedTime);
            }

        }
 
        private void CalculateAnchorPoint() {
            _anchorPoint = (target.position - transform.position) * 0.5f + transform.position;
            _anchorPoint.y += 2;
        }

    }

}
