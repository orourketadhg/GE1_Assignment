using System;
using JetBrains.Annotations;
using UnityEngine;

namespace com.GE1Assignment.Kinematics {

    /**
     * Script to control Inverse Kinematics 
     */
    public class InverseKinematic : MonoBehaviour {

        [Range(2, 4)]
        public int numberOfJoints = 3;
        
        public Transform target;
        public Transform pole;

        private float[] _jointLengths;
        private float _totalLength;
        private Transform[] _joints;
        private Vector3[] _jointPositions;
        
        private void Awake() {
            Init();
        }

        private void LateUpdate() {
            ResolveIK();
        }
        
        /**
         * Initialise bones and joints
         */
        private void Init() {
            _joints = new Transform[numberOfJoints + 1];
            _jointPositions = new Vector3[numberOfJoints + 1];
            _jointLengths = new float[numberOfJoints];

            _totalLength = 0;

            // record joints & the distances between them
            Transform currentBone = transform;
            for (int i = numberOfJoints; i >= 0; i--) {
                _joints[i] = currentBone;

                // check if i is the leaf joint (lowest child)
                if (i != numberOfJoints) {
                    _jointLengths[i] = ( _joints[i + 1].position - currentBone.position ).magnitude;
                    _totalLength += _jointLengths[i];
                }
                
                currentBone = currentBone.parent;
                
            }

        }
        
        /**
         * Resolve the positions & rotations of the joints 
         */
        private void ResolveIK() {
            // get joint positions
            for (int i = 0; i < _joints.Length; i++) {
                _jointPositions[i] = _joints[i].position;
            }
            
            // check if target cannot be reached
            if (( target.position - _joints[0].position ).sqrMagnitude >= _totalLength * _totalLength) {
                // get direction to target
                Vector3 directionToTarget = ( target.position - _jointPositions[0] ).normalized;

                // set joint positions at equal distances (within max range)
                for (int i = 1; i < _jointPositions.Length; i++) {
                    _jointPositions[i] = _jointPositions[i - 1] + (directionToTarget * _jointLengths[i - 1]);
                }
                
            }
            else {
                
                // back
                for (int j = numberOfJoints; j > 0; j--) {
                    
                    if (j == numberOfJoints) {
                        _jointPositions[j] = target.position;
                    }
                    else {
                        _jointPositions[j] = _jointPositions[j + 1] + ( _jointPositions[j] - _jointPositions[j + 1] ).normalized * _jointLengths[j];
                        
                    }
                    
                }
                
                // forward
                for (int j = 1; j < numberOfJoints; j++) {
                    _jointPositions[j] = _jointPositions[j - 1] + ( _jointPositions[j] - _jointPositions[j - 1] ).normalized * _jointLengths[j - 1];
                }
                
            }

            // move joints towards pole
            for (int i = 1; i < numberOfJoints; i++) {
                Plane plane = new Plane(_jointPositions[i + 1] - _jointPositions[i - 1], _jointPositions[i - 1]);
                Vector3 projetedPole = plane.ClosestPointOnPlane(pole.position);
                Vector3 projectedBone = plane.ClosestPointOnPlane(_jointPositions[i]);
                float angle = Vector3.SignedAngle(projectedBone - _jointPositions[i - 1], projetedPole - _jointPositions[i - 1], plane.normal);
                _jointPositions[i] = Quaternion.AngleAxis(angle, plane.normal) * ( _jointPositions[i] - _jointPositions[i - 1] ) + _jointPositions[i - 1];
            }
            
            
            // set joint positions
            for (int i = 0; i < _jointPositions.Length; i++) {
                _joints[i].position = _jointPositions[i];
                
                if (i < numberOfJoints)
                    _joints[i].LookAt(_joints[i + 1]);
                
            }

        }
        
    }
    
}
