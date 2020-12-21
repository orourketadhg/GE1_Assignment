using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.GE1Assignment.Kinematics {

    public class LegController : MonoBehaviour {

        public Transform target;
        public float movementThreshold = 7.5f;
        public float stepSpeed = 1;

        private Vector3 _previousPosition;
        private Vector3 _futurePosition;
        private Vector3 _anchorPoint;
        private float _movementDistance;
        private float _startTime;
        private bool _stepping;
        
        private void Start() {
            _stepping = false;
        }

        private void Update() {
            Step();
        }

        private void Step() {
            
            if (( target.position - transform.position ).sqrMagnitude >= movementThreshold * movementThreshold && !_stepping) {
                _previousPosition = transform.position;
                _futurePosition = target.position;
                CalculateAnchorPoint();
                
                _movementDistance = Vector3.Distance(_previousPosition, _futurePosition);
                _startTime = Time.time;
                _stepping = true;

            }

            if (_stepping) {
                float distanceCovered = ( Time.time - _startTime ) * stepSpeed;
                float distanceToCoverThisFrame = distanceCovered / _movementDistance;

                transform.position = Curves.QuadraticCurve(_previousPosition, _anchorPoint, _futurePosition, distanceToCoverThisFrame);

                if (( _futurePosition - transform.position ).sqrMagnitude < 0.01f * 0.01f) {
                    transform.position = _futurePosition;
                    _stepping = false;
                }

            }

        }
 
        private void CalculateAnchorPoint() {
            _anchorPoint = (_futurePosition - _futurePosition) * 0.5f + _previousPosition;
            _anchorPoint.y += 2;
        }

    }

}
