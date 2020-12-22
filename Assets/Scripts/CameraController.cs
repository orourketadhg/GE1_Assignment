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
            if (_cameraIndex <= 3) {
                transform.position = target.position - cameraSettings[_cameraIndex].cameraOffset;
            }
            else if (_cameraIndex == 4) {
                transform.position = Vector3.zero;
            }
            else if (_cameraIndex > 4) {
                transform.position = target.position - cameraSettings[_cameraIndex].cameraOffset;
                _yaw += rotationSpeed * Time.deltaTime;
                transform.RotateAround(target.position, Vector3.up, _yaw);
            }
            
            transform.LookAt(target);
            
        }

        public void CycleCameraPosition() {
            _cameraIndex += 1;
            _cameraIndex %= cameraSettings.Length;
            
            Debug.Log("Cycling to new camera position: " + cameraSettings[_cameraIndex].cameraPositionName);
        }

    }

    [System.Serializable]
    public struct CameraSettings {
        public string cameraPositionName;
        public Vector3 cameraOffset;
    }

}
