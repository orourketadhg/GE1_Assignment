using UnityEngine;

namespace com.GE1Assignment {

    public class UserInput : MonoBehaviour {

        public static UserInput Instance;
        private Controls _controls;

        public Vector2 speedControl; 

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
                return;
            }

            Instance = this;

            _controls = new Controls();
            
            _controls.Camera.SwitchCameraView.performed += ctx => CameraController.Instance.CycleCameraPosition();

            _controls.Walker.Speed.performed += ctx => speedControl = ctx.ReadValue<Vector2>();
            _controls.Walker.Speed.canceled += ctx => speedControl = Vector2.zero;

        }

        private void OnEnable() {
            _controls.Enable();
        }
    }

}