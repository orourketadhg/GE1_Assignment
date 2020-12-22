using System;
using UnityEngine;

namespace com.GE1Assignment {

    public class CameraController : MonoBehaviour {
        
        public static CameraController Instance;

        public Transform target;
        public float rotationSpeed;
        public CameraSettings[] cameraSettings;
        private int _cameraIndex;
        private float _yaw;
        
        private void Awake() {
            // singleton
            if (Instance != null && Instance != this) {
                Destroy(this);
                return;
            }
            
            Instance = this;
            
        }

        private void Start() {
            _cameraIndex = 0;
        }

        private void FixedUpdate() {
            // stationary potions
            if (_cameraIndex <= 3) {
                transform.position = target.position - cameraSettings[_cameraIndex].cameraOffset;
            }
            // world center
            else if (_cameraIndex == 4) {
                transform.position = Vector3.zero;
            }
            // rotating positions
            else if (_cameraIndex > 4) {
                transform.position = target.position - cameraSettings[_cameraIndex].cameraOffset;
                _yaw += rotationSpeed * Time.deltaTime;
                transform.RotateAround(target.position, Vector3.up, _yaw);
            }
            
            // set camera to look at target
            transform.LookAt(target);
            
        }

        /*
         * Cycle to next camera position
         */
        public void CycleCameraPosition() {
            _cameraIndex += 1;
            _cameraIndex %= cameraSettings.Length;
            
            Debug.Log("Cycling to new camera position: " + cameraSettings[_cameraIndex].cameraPositionName);
        }

    }

    /**
     * Camera position Settings
     */
    [System.Serializable]
    public struct CameraSettings {
        public string cameraPositionName;
        public Vector3 cameraOffset;
    }

}
