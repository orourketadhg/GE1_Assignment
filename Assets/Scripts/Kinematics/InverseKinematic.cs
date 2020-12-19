using System;
using JetBrains.Annotations;
using UnityEngine;

namespace com.GE1Assignment.Kinematics {

    /**
     * Script to control Inverse Kinematics 
     */
    public class InverseKinematic : MonoBehaviour {

        
        public int numBones = 2;
        
        public Transform target;

        private float[] _bonesLengths;
        private float _totalLength;
        private Transform[] _bones;
        private Vector3[] _positions;
        
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
            _bones = new Transform[numBones + 1];
            _positions = new Vector3[numBones + 1];
            _bonesLengths = new float[numBones];

            _totalLength = 0;

            // record joints & the distances between them
            Transform currentBone = transform;
            for (int i = numBones; i >= 0; i--) {
                _bones[i] = currentBone;

                // check if i is the leaf joint (lowest child)
                if (i != numBones) {
                    _bonesLengths[i] = ( _bones[i + 1].position - currentBone.position ).magnitude;
                    _totalLength += _bonesLengths[i];
                }
                
                currentBone = currentBone.parent;
                
            }

        }
        
        /**
         * Resolve the positions & rotations of the joints 
         */
        private void ResolveIK() {
            if (target == null) {
                return;
            }

            if (_bonesLengths.Length != numBones) {
                Init();
            }
            
            // Fabric
            
            for (int i = 0; i < _bones.Length; i++) {
                _positions[i] = _bones[i].position;
            }
            
            // check if target cannot be reached
            if (( target.position - _bones[0].position ).sqrMagnitude >= _totalLength * _totalLength) {
                // get direction to target
                Vector3 directionToTarget = ( target.position - _positions[0] ).normalized;

                // set joint positions at equal distances (within max range)
                for (int i = 1; i < _positions.Length; i++) {
                    _positions[i] = _positions[i - 1] + (directionToTarget * _bonesLengths[i - 1]);
                }
                
            }

            for (int i = 0; i < _positions.Length; i++) {
                _bones[i].position = _positions[i];
            }

        }
        
    }

}
