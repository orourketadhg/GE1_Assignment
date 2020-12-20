using UnityEngine;
using UnityEngine.InputSystem;

namespace com.GE1Assignment.Kinematics {

    public class LegController : MonoBehaviour {

        public Transform target;
        public float movementThreshold;
        public float speed;

        public bool enableMovement;

        private void Update() {

            if (( transform.position - target.position ).sqrMagnitude >= movementThreshold * movementThreshold) {
                enableMovement = true;
            }
            else if (( transform.position - target.position ).sqrMagnitude >= 0.001f * 0.001f) {
                enableMovement = false;
            }

            if (enableMovement) {
                Step();
            }

        }

        private void Step() {
            
        }


    }

}
