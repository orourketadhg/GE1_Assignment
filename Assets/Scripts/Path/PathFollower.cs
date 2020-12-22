using System;
using UnityEngine;

namespace com.GE1Assignment.Path {

    public class PathFollower : MonoBehaviour {

        public float rotationSpeed;
        public float movementSpeed;
        public float threshold = 0.1f;

        private PathBuilder _pathBuilder;
        private Vector3[] _movementPositions;
        private int _positionIndex;
        private Quaternion _lookRotation;

        private void Start() {
            _pathBuilder = FindObjectOfType<PathBuilder>();
            transform.root.position = new Vector3(_pathBuilder.points[0].x, 8, _pathBuilder.points[0].y);

            _movementPositions = new Vector3[_pathBuilder.NumPoints];

            for (int i = 0; i < _pathBuilder.NumPoints; i++) {
                _movementPositions[i] = new Vector3(_pathBuilder.points[i].x, 8, _pathBuilder.points[i].y);
                
            }
            
            Vector3 direction = ( _movementPositions[1] - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);

        }

        private void Update() {

            if (( _movementPositions[_positionIndex] - transform.position ).sqrMagnitude <= threshold * threshold) {
                _positionIndex = ( _positionIndex + 1 ) % _pathBuilder.NumPoints;
                Vector3 direction = ( _movementPositions[_positionIndex] - transform.position).normalized;
                _lookRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);

            }
            else {
                transform.position = Vector3.Lerp(transform.position, _movementPositions[_positionIndex], Time.deltaTime * movementSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);

            }

        }

    }

}
