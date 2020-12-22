using UnityEngine;

namespace com.GE1Assignment {

    public class CameraController : MonoBehaviour {

        public static CameraController Instance;
        
        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
                return;
            }

            Instance = this;
            
        }

        public void CycleCameraPosition() {
            Debug.Log("Cycling to new camera position");
        }

    }

}
